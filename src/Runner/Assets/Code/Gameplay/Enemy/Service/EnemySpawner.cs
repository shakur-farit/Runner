using System;
using System.Linq;
using Assets.Code.Gameplay.Enemy.Factory;
using Assets.Code.Gameplay.Posiotions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Code.Gameplay.Enemy.Service
{
  public class EnemySpawner : IEnemySpawner
  {
    private const int MaxTries = 50;
    private const float LengthOffset = 20f;

    private readonly IEnemyFactory _enemyFactory;
    private readonly IOccupiedPositionsLauncher _positionsLauncher;

    public EnemySpawner(IEnemyFactory enemyFactory, IOccupiedPositionsLauncher positionsLauncher)
    {
      _enemyFactory = enemyFactory;
      _positionsLauncher = positionsLauncher;
    }

    public void SpawnEnemies(int enemyCount, float roadWidth, float roadLength)
    {
      float length = roadLength - LengthOffset;

      EnemyTypeId[] types = Enum.GetValues(typeof(EnemyTypeId))
        .Cast<EnemyTypeId>()
        .Where(t => t != EnemyTypeId.Unknown)
        .ToArray();

      for (int i = 0; i < enemyCount; i++)
      for (int tries = 0; tries < MaxTries; tries++)
      {
        float x = Random.Range(-roadWidth / 2f, roadWidth / 2f);
        float z = Random.Range(-length / 2f, length / 2f);
        Vector3 position = new Vector3(x, 2f, z);

        if (_positionsLauncher.CanPlace(position))
        {
          _positionsLauncher.Add(position);
          EnemyTypeId type = types[Random.Range(0, types.Length)];
          _enemyFactory.CreateEnemy(type, position);
          break;
        }
      }
    }
  }
}