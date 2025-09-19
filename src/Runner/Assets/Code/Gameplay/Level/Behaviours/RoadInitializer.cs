using UnityEngine;

namespace Assets.Code.Gameplay.Level.Behaviours
{
	public class RoadInitializer : MonoBehaviour
	{
		private const float RoadHeight = 0.5f;

		[SerializeField] private Environment _environment;
		[SerializeField] private Transform _road;

		private void Start()
		{
			_road.localScale = new(
				_environment.RoadWidth, RoadHeight, _environment.RoadLength);
		}
	}
}