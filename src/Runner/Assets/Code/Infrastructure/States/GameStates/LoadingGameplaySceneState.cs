using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
	public class LoadingGameplaySceneState : IPayloadState<string>
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly ISceneLoader _sceneLoader;

		public LoadingGameplaySceneState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
		}

		public void Enter(string sceneName)
		{
			_sceneLoader.LoadScene(sceneName, EnterBattleLoopState);
		}

		public void Exit()
		{
		}

		private void EnterBattleLoopState()
		{
			_stateMachine.Enter<GameplayState>();
		}
	}
}