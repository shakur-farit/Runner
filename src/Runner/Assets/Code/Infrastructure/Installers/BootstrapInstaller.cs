using Assets.Code.Gameplay.Camera.Service;
using Assets.Code.Gameplay.Character.Factory;
using Assets.Code.Gameplay.Death;
using Assets.Code.Gameplay.Enemy.Factory;
using Assets.Code.Gameplay.Enemy.Service;
using Assets.Code.Gameplay.Input;
using Assets.Code.Gameplay.Level.Factory;
using Assets.Code.Gameplay.Loot.Factory;
using Assets.Code.Gameplay.Loot.Service;
using Assets.Code.Gameplay.Posiotions;
using Assets.Code.Gameplay.Restart;
using Assets.Code.Gameplay.SoundEffect.Factory;
using Assets.Code.Infrastructure.AssetsProvider;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.Factory;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.StaticData;
using Assets.Code.Meta.UI.Windows.Factory;
using Assets.Code.Meta.UI.Windows.Service;
using Zenject;

namespace Assets.Code.Infrastructure.Installers
{
	public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
	{
		public override void InstallBindings()
		{
			BindStateMachine();
			BindStateMachineFactory();
			BindInfrastructureServices();
			BindGameStates();
			BindGameplayServices();
			BindGameplayFactories();
			BindUIServices();
			BindUIFactories();
		}

		private void BindStateMachine() => 
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

		private void BindStateMachineFactory() => 
			Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

		private void BindGameStates()
		{
			Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadStaticDataState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingHomeScreenSceneState>().AsSingle();
			Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingGameplaySceneState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LevelCompleteState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
		}

		private void BindInfrastructureServices()
		{
			Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
			Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
		}

		public void BindGameplayServices()
		{
			Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
			Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
			Container.Bind<IDeathService>().To<DeathService>().AsSingle();
			Container.Bind<IRestartingService>().To<RestartingService>().AsSingle();
			Container.Bind<ILootPickupService>().To<LootPickupService>().AsSingle();
      Container.BindInterfacesAndSelfTo<CoinService>().AsSingle();
      Container.Bind<IEnemySpawner>().To<EnemySpawner>().AsSingle();
      Container.Bind<ILootSpawner>().To<LootSpawner>().AsSingle();
      Container.Bind<IOccupiedPositionsLauncher>().To<OccupiedPositionsLauncher>().AsSingle();
    }

		public void BindGameplayFactories()
		{
			Container.Bind<ILevelFactory>().To<LevelFactory>().AsSingle();
			Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
			Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
			Container.Bind<ILootFactory>().To<LootFactory>().AsSingle();
			Container.Bind<ISoundEffectFactory>().To<SoundEffectFactory>().AsSingle();
		}

		public void BindUIServices() => 
			Container.Bind<IWindowService>().To<WindowService>().AsSingle();

		public void BindUIFactories() =>
			Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();

		public void Initialize() => 
			Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
  }
}
