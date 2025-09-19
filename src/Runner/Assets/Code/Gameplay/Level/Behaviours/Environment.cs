using UnityEngine;

namespace Assets.Code.Gameplay.Level.Behaviours
{
	public class Environment : MonoBehaviour
	{
		public Vector3 StartPosition { get; private set; }
		public float RoadLength { get; private set; }
		public float RoadWidth { get; private set; }
		public int EnemiesCount { get; private set; }
		public int LootCount { get; private set; }
		public float FinishZPosition { get; private set; }

		public void Setup(Vector3 startPosition, float length, float width, int enemiesCount, int lootCount, float finishXPosition)
		{
			StartPosition = startPosition;
			RoadLength = length;
			RoadWidth = width;
      EnemiesCount = enemiesCount;
      LootCount = lootCount;
			FinishZPosition = finishXPosition;
		}
	}
}