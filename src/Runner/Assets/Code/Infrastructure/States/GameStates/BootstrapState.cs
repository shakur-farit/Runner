using Assets.Code.Infrastructure.AssetsProvider;
using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.StaticData;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly IAssetProvider _assetProvider;
		private readonly IStaticDataService _staticDataService;

		public BootstrapState(
			IGameStateMachine stateMachine, 
			IAssetProvider assetProvider,
			IStaticDataService staticDataService)
		{
			_stateMachine = stateMachine;
			_assetProvider = assetProvider;
			_staticDataService = staticDataService;
		}
		public async void Enter()
		{
			await _assetProvider.Initialize();
			await _staticDataService.LoadAll();

			_stateMachine.Enter<LoadStaticDataState>();
		}

		public void Exit()
		{
		}
	}
}