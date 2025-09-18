using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class HeroMover : MonoBehaviour
  {
    [SerializeField] private Hero _hero;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private HeroAnimator _heroAnimator;
    
    private IInputService _input;

    [Inject]
    public void Constructor(IInputService input) => 
      _input = input;

    private void FixedUpdate() => 
      Move();

    private void Move()
    {
      float horizontalInput = _input.GetHorizontalAxis();
      Vector3 move = new Vector3(horizontalInput * _hero.MovementSpeed, _rigidbody.velocity.y, _hero.MovementSpeed);

      _rigidbody.velocity = move;

      _heroAnimator.StartMoving();
    }
  }
}