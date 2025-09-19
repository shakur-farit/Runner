using UnityEngine;

namespace Assets.Code.Gameplay.Loot.Config
{
  [CreateAssetMenu(menuName = "Runner/Loot Config", fileName = "LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public LootTypeId TypeId;
    public GameObject Prefab;
    public int Value;
  }
}