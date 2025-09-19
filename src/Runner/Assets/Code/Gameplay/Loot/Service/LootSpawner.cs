using System;
using System.Linq;
using Assets.Code.Gameplay.Loot.Factory;
using Assets.Code.Gameplay.Posiotions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Code.Gameplay.Loot.Service
{
  public class LootSpawner : ILootSpawner
  {
    private const int MaxTries = 50;
    private const float LengthOffset = 20f;

    private readonly ILootFactory _lootFactory;
    private readonly IOccupiedPositionsLauncher _positionsLauncher;

    public LootSpawner(ILootFactory lootFactory, IOccupiedPositionsLauncher positionsLauncher)
    {
      _lootFactory = lootFactory;
      _positionsLauncher = positionsLauncher;
    }

    public void SpawnLoot(int lootCount, float roadWidth, float roadLength)
    {
      float length = roadLength - LengthOffset;

      LootTypeId[] types = Enum.GetValues(typeof(LootTypeId))
        .Cast<LootTypeId>()
        .Where(t => t != LootTypeId.Unknown)
        .ToArray();

      for (int i = 0; i < lootCount; i++)
      for (int tries = 0; tries < MaxTries; tries++)
      {
        float x = Random.Range(-roadWidth / 2f, roadWidth / 2f);
        float z = Random.Range(-length / 2f, length / 2f);
        Vector3 position = new Vector3(x, 2f, z);

        if (_positionsLauncher.CanPlace(position))
        {
          _positionsLauncher.Add(position);
          LootTypeId type = types[Random.Range(0, types.Length)];
          _lootFactory.CreateLoot(type, position);
          break;
        }
      }
    }
  }
}