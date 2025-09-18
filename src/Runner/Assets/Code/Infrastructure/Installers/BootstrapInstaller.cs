using Code.Infrastructure.AssetsProvider;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using Code.Meta.Ui.Windows.Factory;
using Zenject;

namespace Code.Infrastructure.Installers
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
		}

		public void BindGameplayFactories()
		{
			Container.Bind<ILevelFactory>().To<LevelFactory>().AsSingle();
			Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
		}

		public void BindUIServices() => 
			Container.Bind<IWindowService>().To<WindowService>().AsSingle();

		public void BindUIFactories() =>
			Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();

		public void Initialize() => 
			Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
	}
}
