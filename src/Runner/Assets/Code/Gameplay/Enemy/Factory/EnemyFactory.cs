using Assets.Code.Gameplay.Enemy.Config;
using Assets.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Enemy.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IInstantiator _instantiator;

    public EnemyFactory(IStaticDataService staticDataService, IInstantiator instantiator)
    {
      _staticDataService = staticDataService;
      _instantiator = instantiator;
    }

    public Behaviours.Enemy CreateEnemy(EnemyTypeId typeId, Vector3 at)
    {
      EnemyConfig config = _staticDataService.GetEnemyConfig(typeId);

      Behaviours.Enemy enemy =
        _instantiator.InstantiatePrefabForComponent<Behaviours.Enemy>(config.Prefab, at, Quaternion.identity, null);

      enemy
        .Setup(config.MaxMovementSpeed);

      return enemy;
    }
  }
}