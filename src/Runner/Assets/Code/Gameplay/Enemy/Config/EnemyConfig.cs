using UnityEngine;

namespace Assets.Code.Gameplay.Enemy.Config
{
  [CreateAssetMenu(menuName = "Runner/Enemy Config", fileName = "EnemyConfig")]
  public class EnemyConfig : ScriptableObject
  {
    public EnemyTypeId TypeId;
    public GameObject Prefab;
    public float MaxMovementSpeed;
  }
}