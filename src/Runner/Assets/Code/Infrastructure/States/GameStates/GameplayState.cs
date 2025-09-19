using Code.Infrastructure.Installers;
using Code.Infrastructure.States.Infrastructure;
using Code.Meta.Ui.Windows;
using Code.Meta.Ui.Windows.Factory;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly ILevelFactory _levelFactory;
		private readonly IHeroFactory _heroFactory;
		private readonly ICameraProvider _cameraProvider;
		private readonly IWindowService _windowService;

		public GameplayState(
			ILevelFactory levelFactory,
			IHeroFactory heroFactory,
			ICameraProvider cameraProvider,
			IWindowService windowService)
		{
			_levelFactory = levelFactory;
			_heroFactory = heroFactory;
			_cameraProvider = cameraProvider;
			_windowService = windowService;
		}

		public void Enter()
		{
			_windowService.Open(WindowId.Hud);
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