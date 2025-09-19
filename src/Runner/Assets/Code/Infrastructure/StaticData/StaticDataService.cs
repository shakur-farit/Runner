using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Gameplay.Character.Config;
using Assets.Code.Gameplay.Enemy;
using Assets.Code.Gameplay.Enemy.Config;
using Assets.Code.Gameplay.Level;
using Assets.Code.Gameplay.Level.Config;
using Assets.Code.Gameplay.Loot;
using Assets.Code.Gameplay.Loot.Config;
using Assets.Code.Gameplay.SoundEffect;
using Assets.Code.Gameplay.SoundEffect.Config;
using Assets.Code.Infrastructure.AssetsProvider;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Assets.Code.Infrastructure.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string WindowConfigLabel = "WindowConfig";
		private const string LevelConfigLabel = "LevelConfig";
		private const string HeroConfigLabel = "HeroConfig";
		private const string EnemyConfigLabel = "EnemyConfig";
		private const string LootConfigLabel = "LootConfig";
		private const string SoundEffectConfigLabel = "SoundEffectConfig";

		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<LevelTypeId, LevelConfig> _levelById;
		private Dictionary<EnemyTypeId, EnemyConfig> _enemyById;
		private Dictionary<LootTypeId, LootConfig> _lootById;
		private Dictionary<SoundEffectTypeId, SoundEffectConfig> _soundEffectById;
		private HeroConfig _heroConfig;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) => 
			_assetProvider = assetProvider;

		public async UniTask LoadAll()
		{
			await LoadWindows();
			await LoadLevels();
			await LoadHero();
      await LoadEnemies();
      await LoadLoots();
      await LoadSoundEffects();
    }

		public WindowConfig GetWindowConfig(WindowId id)
		{
			if (_windowById.TryGetValue(id, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {id} was not found");
		}

		public LevelConfig GetLevelConfig(LevelTypeId typeId)
		{
			if (_levelById.TryGetValue(typeId, out LevelConfig config))
				return config;

			throw new Exception($"Level config for {typeId} was not found");
		}

		public HeroConfig GetHeroConfig() => 
			_heroConfig;

    public EnemyConfig GetEnemyConfig(EnemyTypeId typeId)
    {
      if (_enemyById.TryGetValue(typeId, out EnemyConfig config))
        return config;

      throw new Exception($"Enemy config for {typeId} was not found");
    }

    public LootConfig GetLootConfig(LootTypeId typeId)
    {
      if (_lootById.TryGetValue(typeId, out LootConfig config))
        return config;

      throw new Exception($"Loot config for {typeId} was not found");
    }

    public SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId typeId)
    {
      if (_soundEffectById.TryGetValue(typeId, out SoundEffectConfig config))
        return config;

      throw new Exception($"Sound effect config for {typeId} was not found");
    }

    private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadLevels() =>
			_levelById = (await _assetProvider.LoadAll<LevelConfig>(LevelConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadHero() =>
			_heroConfig = await _assetProvider.Load<HeroConfig>(HeroConfigLabel);

    private async UniTask LoadEnemies() =>
      _enemyById = (await _assetProvider.LoadAll<EnemyConfig>(EnemyConfigLabel))
        .ToDictionary(x => x.TypeId, x => x);

    private async UniTask LoadLoots() =>
      _lootById = (await _assetProvider.LoadAll<LootConfig>(LootConfigLabel))
        .ToDictionary(x => x.TypeId, x => x);

    private async UniTask LoadSoundEffects() =>
      _soundEffectById = (await _assetProvider.LoadAll<SoundEffectConfig>(SoundEffectConfigLabel))
        .ToDictionary(x => x.TypeId, x => x);
  }
}