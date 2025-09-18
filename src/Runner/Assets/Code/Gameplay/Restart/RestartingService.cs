using System;

namespace Code.Infrastructure.Installers
{
  public class RestartingService : IRestartingService
  {
    public event Action Restarted;

    public void Restart() => 
      Restarted?.Invoke();
  }
}