using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class HeroCollider : MonoBehaviour
  {
	  private const int CoinValue = 1;

    private IDeathService _deathService;
    private IGameStateMachine _stateMachine;
    private ICoinService _coinService;

    [Inject]
    public void Constructor(
	    IDeathService deathService, 
	    IGameStateMachine stateMachine,
	    ICoinService coinService)
    {
      _deathService = deathService;
      _stateMachine = stateMachine;
      _coinService = coinService;
    }

    private void OnTriggerEnter(Collider other)
    {
      CollideWithEnemy(other);
      CrossTheFinish(other);
      Pickup(other);
    }

    private void CollideWithEnemy(Collider other)
    {
      if (other.gameObject.layer == (int)CollisionLayer.Enemy)
      {
        _deathService.Die(gameObject);
        _stateMachine.Enter<GameOverState>();
      }
    }

    private void CrossTheFinish(Collider other)
    {
      if (other.gameObject.layer == (int)CollisionLayer.Finish)
      {
        _deathService.Die(gameObject);
        _stateMachine.Enter<LevelCompleteState>();
      }
    }

    private void Pickup(Collider other)
    {
	    if (other.gameObject.layer == (int)CollisionLayer.Collectable)
		    if (other.TryGetComponent(out Coin coin))
			    _coinService.ChangeCoinCount(coin.Value);
    }
  }
}