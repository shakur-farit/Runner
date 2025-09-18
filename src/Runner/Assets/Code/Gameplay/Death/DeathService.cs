using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Infrastructure.Installers
{
  public class DeathService : IDeathService
  {
    public void Die(GameObject gameObject) => 
      Object.Destroy(gameObject);
  }
}