using UnityEngine;

namespace Code.Infrastructure.Installers
{
	[CreateAssetMenu(menuName = "Runner/Level Config", fileName = "LevelConfig")]
	public class LevelConfig : ScriptableObject
	{
		public LevelTypeId TypeId;
		public GameObject Environment;
		public float RoadLength;
		public float RoadWidth;
		public Vector3 StartHeroPosition;
		public float FinishZPosiotion;
	}
}