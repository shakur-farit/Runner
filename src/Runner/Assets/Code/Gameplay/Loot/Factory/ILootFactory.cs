using UnityEngine;

namespace Assets.Code.Gameplay.Loot.Factory
{
  public interface ILootFactory
  {
    Behaviours.Loot CreateLoot(LootTypeId typeId, Vector3 at);
  }
}