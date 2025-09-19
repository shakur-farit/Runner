using UnityEngine;

namespace Assets.Code.Gameplay.Enemy.Factory
{
  public interface IEnemyFactory
  {
    Behaviours.Enemy CreateEnemy(EnemyTypeId typeId,Vector3 at);
  }
}