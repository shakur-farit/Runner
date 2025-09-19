using Assets.Code.Gameplay.Loot.Config;
using Assets.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Loot.Factory
{
  public class LootFactory : ILootFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IInstantiator _instantiator;

    public LootFactory(IStaticDataService staticDataService, IInstantiator instantiator)
    {
      _staticDataService = staticDataService;
      _instantiator = instantiator;
    }

    public Behaviours.Loot CreateLoot(LootTypeId typeId, Vector3 at)
    {
      LootConfig config = _staticDataService.GetLootConfig(typeId);

      Behaviours.Loot loot=
        _instantiator.InstantiatePrefabForComponent<Behaviours.Loot>(config.Prefab, at, Quaternion.identity, null);

      loot
        .Setup(
          typeId, 
          config.Value);

      return loot;
    }
  }
}