using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.Infrastructure;
using Zenject;
using IState = Code.Infrastructure.States.Infrastructure.IState;

namespace Code.Infrastructure.States.StateMachine
{
	public class GameStateMachine : ITickable, IGameStateMachine
	{
		private IExitableState _activeState;
		private readonly IStateFactory _stateFactory;

		public GameStateMachine(IStateFactory stateFactory)
		{
			_stateFactory = stateFactory;
		}

		public void Tick()
		{
			if (_activeState is IUpdateable updateableState)
				updateableState.Update();
		}

		public void Enter<TState>() where TState : class, IState
		{
			IState state = ChangeState<TState>();
			state.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
		{
			TState state = ChangeState<TState>();
			state.Enter(payload);
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			_activeState?.Exit();

			TState state = _stateFactory.GetState<TState>();
			_activeState = state;

			return state;
		}
	}
}