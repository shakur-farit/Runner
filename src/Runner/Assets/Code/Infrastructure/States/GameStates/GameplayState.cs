using Code.Infrastructure.Installers;
using Code.Infrastructure.States.Infrastructure;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly ILevelFactory _levelFactory;
		private readonly IHeroFactory _heroFactory;
		private readonly ICameraProvider _cameraProvider;

		public GameplayState(
			ILevelFactory levelFactory,
			IHeroFactory heroFactory,
			ICameraProvider cameraProvider)
		{
			_levelFactory = levelFactory;
			_heroFactory = heroFactory;
			_cameraProvider = cameraProvider;
		}

		public void Enter()
		{
			Environment environment = _levelFactory.CreateLevel(LevelTypeId.First);
			Hero hero = _heroFactory.CreateHero(environment.StartPosition, environment.RoadWidth);

			SetCameraFollowTarget(hero.transform);
		}

		public void Exit()
		{
		}

		private void SetCameraFollowTarget(Transform transform) => 
			_cameraProvider.SetFollowTarget(transform);
	}
}