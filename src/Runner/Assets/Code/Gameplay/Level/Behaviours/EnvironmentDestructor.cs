using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class EnvironmentDestructor : MonoBehaviour
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