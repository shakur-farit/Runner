using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class HeroJumper : MonoBehaviour
  {
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Hero _hero;

    private IInputService _input;
    private bool _isGrounded;

    [Inject]
    public void Construct(IInputService input) => 
      _input = input;

    private void Update()
    {
      CheckGround();

      if (_input.GetJumpButtonDown() && _isGrounded) 
        Jump();
    }

    private void Jump() => 
      _rigidbody.AddForce(Vector3.up * _hero.JumpForce, ForceMode.Impulse);

    private void CheckGround() => 
      _isGrounded = Physics.CheckSphere(groundCheck.position, _hero.GroundCheckRadius, groundLayer);

    private void OnDrawGizmosSelected()
    {
      if (groundCheck != null)
      {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, _hero.GroundCheckRadius);
      }
    }
  }
}