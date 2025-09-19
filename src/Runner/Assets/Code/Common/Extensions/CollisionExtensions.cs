using UnityEngine;

namespace Assets.Code.Common.Extensions
{

  public enum CollisionLayer
  {
    Hero = 6,
    Enemy = 7,
    Collectable = 8,
    Finish = 9
  }

  public static class CollisionExtensions
  {
    public static bool Matches(this Collider2D collider, LayerMask layerMask) =>
      ((1 << collider.gameObject.layer) & layerMask) != 0;

    public static int AsMask(this CollisionLayer layer) =>
      1 << (int)layer;
  }
}