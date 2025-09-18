using UnityEngine;

namespace Code.Infrastructure.Installers
{
	[CreateAssetMenu(menuName = "Runner/Hero Config", fileName = "HeroConfig")]
	public class HeroConfig : ScriptableObject
	{
		public GameObject Prefab;
		public float MovementSpeed;
	}
}