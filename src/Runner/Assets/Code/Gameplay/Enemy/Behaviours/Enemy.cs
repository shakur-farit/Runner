using UnityEngine;

namespace Assets.Code.Gameplay.Enemy.Behaviours
{
  public class Enemy : MonoBehaviour
  {
    public float MaxMovementSpeed { get; private set; }

    public void Setup(float movementSpeed) => 
      MaxMovementSpeed = movementSpeed;
  }
}