using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Gameplay.Posiotions
{
  public class OccupiedPositionsLauncher : IOccupiedPositionsLauncher
  {
    private const float MinDistance = 2f;

    private readonly List<Vector3> _occupiedPositions = new();

    public bool CanPlace(Vector3 position)
    {
      foreach (Vector3 occupiedPosition in _occupiedPositions)
      {
        if (Mathf.Abs(occupiedPosition.z - position.z) < MinDistance)
          return false;
      }
      return true;
    }

    public void Add(Vector3 position) => 
      _occupiedPositions.Add(position);
  }
}