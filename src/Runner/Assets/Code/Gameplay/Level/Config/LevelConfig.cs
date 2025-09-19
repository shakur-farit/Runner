using UnityEngine;

namespace Assets.Code.Gameplay.Level.Config
{
	[CreateAssetMenu(menuName = "Runner/Level Config", fileName = "LevelConfig")]
	public class LevelConfig : ScriptableObject
	{
		public LevelTypeId TypeId;
		public GameObject Environment;
		public float RoadLength;
		public float RoadWidth;
		public int EnemiesCount;
		public int LootCount;
		public Vector3 StartHeroPosition;
		public float FinishZPosiotion;
	}
}