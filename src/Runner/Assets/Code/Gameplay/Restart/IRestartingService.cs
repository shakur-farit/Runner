using System;

namespace Assets.Code.Gameplay.Restart
{
  public interface IRestartingService
  {
    event Action Restarted;
    void Restart();
  }
}