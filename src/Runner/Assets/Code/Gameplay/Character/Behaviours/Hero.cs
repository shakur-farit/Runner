using UnityEngine;

namespace Assets.Code.Gameplay.Character.Behaviours
{
	public class Hero : MonoBehaviour
	{
    public float MovementSpeed { get; private set; }
    public float JumpForce { get; private set; }
    public float GroundCheckRadius { get; private set; }
    public float XClamp { get; private set; }
    public bool IsGrounded { get; set; }

		public void Setup(Vector3 startPosition, float movementSpeed, 
			float jumpForce, float checkRadius, float xClamp)
    {
      gameObject.transform.position = startPosition;
      MovementSpeed = movementSpeed;
      JumpForce = jumpForce;
      GroundCheckRadius = checkRadius;
      XClamp = xClamp;
    }
  }
}