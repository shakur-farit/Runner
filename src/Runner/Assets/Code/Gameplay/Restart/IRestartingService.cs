using System;

namespace Code.Infrastructure.Installers
{
  public interface IRestartingService
  {
    event Action Restarted;
    void Restart();
  }
}