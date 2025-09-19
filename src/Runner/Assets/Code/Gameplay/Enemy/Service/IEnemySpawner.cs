namespace Assets.Code.Gameplay.Enemy.Service
{
  public interface IEnemySpawner
  {
    void SpawnEnemies(int enemyCount, float roadWidth, float roadLength);
  }
}