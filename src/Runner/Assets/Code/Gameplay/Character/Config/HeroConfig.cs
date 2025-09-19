using UnityEngine;

namespace Assets.Code.Gameplay.Character.Config
{
	[CreateAssetMenu(menuName = "Runner/Hero Config", fileName = "HeroConfig")]
	public class HeroConfig : ScriptableObject
	{
		public GameObject Prefab;
		public float MovementSpeed;
    public float JumpForce;
    public float GroundCheckRadius;
  }
}