namespace Assets.Code.Gameplay.Loot.Service
{
  public interface ILootPickupService
  {
    void Pickup(LootTypeId typeId, int value);
  }
}