using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Code.Gameplay.Death
{
  public class DeathService : IDeathService
  {
    public void Die(GameObject gameObject) => 
      Object.Destroy(gameObject);
  }
}