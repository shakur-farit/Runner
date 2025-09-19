using UnityEngine;

namespace Assets.Code.Gameplay.Posiotions
{
  public interface IOccupiedPositionsLauncher
  {
    bool CanPlace(Vector3 position);
    void Add(Vector3 position);
  }
}