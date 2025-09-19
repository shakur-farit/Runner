using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class HeroMover : MonoBehaviour
  {
    [SerializeField] private Hero _hero;
    [SerializeField] private HeroAnimator _heroAnimator;
    
    private IInputService _input;

    [Inject]
    public void Constructor(IInputService input) => 
      _input = input;

    private void FixedUpdate() => 
      Move();

    private void Move()
    {
	    Vector3 currentPosition = transform.position;

	    float xInput = _hero.IsGrounded ? _input.GetHorizontalAxis() : 0f;
	    float xMove = xInput * _hero.MovementSpeed * Time.fixedDeltaTime;

	    float zMove = _hero.MovementSpeed * Time.fixedDeltaTime;

	    currentPosition.x += xMove;
	    currentPosition.z += zMove;

	    float halfClamp = _hero.XClamp / 2f;
	    currentPosition.x = Mathf.Clamp(currentPosition.x, -halfClamp, halfClamp);

	    transform.position = currentPosition;

	    _heroAnimator.StartMoving();
		}
  }
}