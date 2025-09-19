using Assets.Code.Gameplay.Level.Behaviours;
using Assets.Code.Gameplay.Level.Config;
using Assets.Code.Infrastructure.StaticData;
using Zenject;

namespace Assets.Code.Gameplay.Level.Factory
{
	public class LevelFactory : ILevelFactory
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IInstantiator _instantiator;

		public LevelFactory(IStaticDataService staticDataService, IInstantiator instantiator)
		{
			_staticDataService = staticDataService;
			_instantiator = instantiator;
		}

		public Environment CreateLevel(LevelTypeId typeId)
		{
			LevelConfig config = _staticDataService.GetLevelConfig(typeId);

			Environment environment = 
				_instantiator.InstantiatePrefabForComponent<Environment>(config.Environment);

			environment
				.Setup(
				config.StartHeroPosition,
				config.RoadLength,
				config.RoadWidth,
				config.EnemiesCount,
				config.LootCount,
				config.FinishZPosiotion);

			return environment;
		}
	}
}