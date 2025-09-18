using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class Hero : MonoBehaviour
	{
    public float MovementSpeed { get; private set; }
    public float JumpForce { get; private set; }
    public float GroundCheckRadius { get; private set; }

		public void Setup(Vector3 startPosition, float movementSpeed, float jumpForce, float checkRadius)
    {
      gameObject.transform.position = startPosition;
      MovementSpeed = movementSpeed;
      JumpForce = jumpForce;
      GroundCheckRadius = checkRadius;
    }
  }
}