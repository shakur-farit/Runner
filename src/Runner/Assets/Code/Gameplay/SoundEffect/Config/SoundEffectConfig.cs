using UnityEngine;

namespace Assets.Code.Gameplay.SoundEffect.Config
{
  [CreateAssetMenu(menuName = "Runner/Sound Effect Config", fileName = "SoundEffectConfig")]
  public class SoundEffectConfig : ScriptableObject
  {
    public SoundEffectTypeId TypeId;
    public GameObject Prefab;
    public AudioClip AudioClip;
  }
}