using Code.Infrastructure.AssetsProvider;
using Code.Meta.Ui.Windows;
using Code.Meta.Ui.Windows.Behaviours;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Installers;
namespace Code.Infrastructure.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string WindowConfigLabel = "WindowConfig";
		private const string LevelConfigLabel = "LevelConfig";
		private const string HeroConfigLabel = "HeroConfig";

		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<LevelTypeId, LevelConfig> _levelById;
		private HeroConfig _heroConfig;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) => 
			_assetProvider = assetProvider;

		public async UniTask LoadAll()
		{
			await LoadWindows();
			await LoadLevels();
			await LoadHero();
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

		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadLevels() =>
			_levelById = (await _assetProvider.LoadAll<LevelConfig>(LevelConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadHero() =>
			_heroConfig = await _assetProvider.Load<HeroConfig>(HeroConfigLabel);

	}
}