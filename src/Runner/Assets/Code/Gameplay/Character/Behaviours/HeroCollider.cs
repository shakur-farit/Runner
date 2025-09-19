using Assets.Code.Common.Extensions;
using Assets.Code.Gameplay.Death;
using Assets.Code.Gameplay.Loot.Service;
using Assets.Code.Gameplay.SoundEffect;
using Assets.Code.Gameplay.SoundEffect.Factory;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Character.Behaviours
{
  public class HeroCollider : MonoBehaviour
  {
    private IDeathService _deathService;
    private IGameStateMachine _stateMachine;
    private ILootPickupService _lootPickupService;
    private ISoundEffectFactory _soundEffectFactory;

    [Inject]
    public void Constructor(
	    IDeathService deathService, 
	    IGameStateMachine stateMachine,
      ILootPickupService lootPickupService,
      ISoundEffectFactory soundEffectFactory)
    {
      _deathService = deathService;
      _stateMachine = stateMachine;
      _lootPickupService = lootPickupService;
      _soundEffectFactory = soundEffectFactory;
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
        _soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Lose, transform.position);
        _stateMachine.Enter<GameOverState>();
      }
    }

    private void CrossTheFinish(Collider other)
    {
      if (other.gameObject.layer == (int)CollisionLayer.Finish)
      {
        _deathService.Die(gameObject);
        _stateMachine.Enter<LevelCompleteState>();
        _soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Win, transform.position);
      }
    }

    private void Pickup(Collider other)
    {
      if (other.gameObject.layer == (int)CollisionLayer.Collectable)
      {
        if (other.TryGetComponent(out Loot.Behaviours.Loot loot))
        {
          _lootPickupService.Pickup(loot.TypeId, loot.Value);
          loot.CallPickedup();
        }

        _soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Pickup, transform.position);
      }
    }
  }
}