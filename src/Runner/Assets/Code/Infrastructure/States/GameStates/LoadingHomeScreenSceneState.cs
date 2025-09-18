using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
	public class LoadingHomeScreenSceneState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly ISceneLoader _sceneLoader;

		public LoadingHomeScreenSceneState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
		}

		public void Enter() => 
			_sceneLoader.LoadScene(Scenes.HomeScreen, EnterHomeScreenState);

		public void Exit()
		{
		}

		private void EnterHomeScreenState() => 
			_gameStateMachine.Enter<HomeScreenState>();
	}
}