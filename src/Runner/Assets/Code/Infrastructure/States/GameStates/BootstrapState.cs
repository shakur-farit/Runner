using Code.Infrastructure.AssetsProvider;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
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