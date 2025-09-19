using Assets.Code.Gameplay.Camera.Service;
using Assets.Code.Gameplay.Character.Behaviours;
using Assets.Code.Gameplay.Character.Factory;
using Assets.Code.Gameplay.Enemy.Service;
using Assets.Code.Gameplay.Level;
using Assets.Code.Gameplay.Level.Behaviours;
using Assets.Code.Gameplay.Level.Factory;
using Assets.Code.Gameplay.Loot.Service;
using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Service;
using UnityEngine;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly ILevelFactory _levelFactory;
		private readonly IHeroFactory _heroFactory;
    private readonly IEnemySpawner _enemySpawner;
    private readonly ILootSpawner _lootSpawner;
    private readonly ICameraProvider _cameraProvider;
		private readonly IWindowService _windowService;

		public GameplayState(
			ILevelFactory levelFactory,
			IHeroFactory heroFactory,
			IEnemySpawner enemySpawner,
			ILootSpawner lootSpawner,
			ICameraProvider cameraProvider,
			IWindowService windowService)
		{
			_levelFactory = levelFactory;
			_heroFactory = heroFactory;
      _enemySpawner = enemySpawner;
      _lootSpawner = lootSpawner;
      _cameraProvider = cameraProvider;
			_windowService = windowService;
		}

		public void Enter()
		{
			OpenHudWindow();

			Environment environment = CreateEnvironment();
			SpawnEnemies(environment);
      SpawnLoot(environment);
      Hero hero = SpawnHero(environment);

			SetCameraFollowTarget(hero.transform);

      AudioSource audioSource = _cameraProvider.MainCamera.GetComponent<AudioSource>();
      audioSource.Play();
    }

    public void Exit()
		{
		}

    private Environment CreateEnvironment() => 
      _levelFactory.CreateLevel(LevelTypeId.First);

    private void SpawnEnemies(Environment environment) => 
      _enemySpawner.SpawnEnemies(environment.EnemiesCount, environment.RoadWidth, environment.RoadLength);

    private void SpawnLoot(Environment environment) => 
      _lootSpawner.SpawnLoot(environment.LootCount, environment.RoadWidth, environment.RoadLength);

    private void OpenHudWindow() => 
      _windowService.Open(WindowId.Hud);

    private Hero SpawnHero(Environment environment) => 
      _heroFactory.CreateHero(environment.StartPosition, environment.RoadWidth);

    private void SetCameraFollowTarget(Transform transform) => 
			_cameraProvider.SetFollowTarget(transform);
	}
}