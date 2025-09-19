using Assets.Code.Gameplay.Character.Behaviours;
using Assets.Code.Gameplay.Character.Config;
using Assets.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Character.Factory
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

		public Hero CreateHero(Vector3 at, float roadWidth)
		{
			HeroConfig config = _staticDataService.GetHeroConfig();

			Hero hero = _instantiator.InstantiatePrefabForComponent<Hero>(config.Prefab);

			hero
				.Setup(
					at, 
					config.MovementSpeed, 
					config.JumpForce, 
					config.GroundCheckRadius,
					roadWidth);

			return hero;
		}
	}
}