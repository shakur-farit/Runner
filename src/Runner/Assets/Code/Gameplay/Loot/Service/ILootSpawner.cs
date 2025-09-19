namespace Assets.Code.Gameplay.Loot.Service
{
  public interface ILootSpawner
  {
    void SpawnLoot(int enemyCount, float roadWidth, float roadLength);
  }
}