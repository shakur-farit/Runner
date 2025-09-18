using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class HeroFactory : IHeroFactory
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IInstantiator _instantiator;

		public HeroFactory(IStaticDataService staticDataService, IInstantiator instantiator)
		{
			_staticDataService = staticDataService;
			_instantiator = instantiator;
		}

		public Hero CreateHero(Vector3 at)
		{
			HeroConfig config = _staticDataService.GetHeroConfig();

			Hero hero = _instantiator.InstantiatePrefabForComponent<Hero>(config.Prefab);

			hero.SetStartPosition(at);

			return hero;
		}
	}
}