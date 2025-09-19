using Assets.Code.Gameplay.Restart;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Loot.Behaviours
{
  public class LootDestructor : MonoBehaviour
  {
    private IRestartingService _restarting;

    [Inject]
    public void Constructor(IRestartingService restarting) =>
      _restarting = restarting;

    public void OnEnable() =>
      _restarting.Restarted += DestroyEnvironment;

    public void OnDisable() =>
      _restarting.Restarted -= DestroyEnvironment;

    private void DestroyEnvironment() =>
      Destroy(gameObject);
  }
}