using System;

namespace Code.Infrastructure.Installers
{
  public class RestartingService : IRestartingService
  {
	  public event Action Restarted;

	  private readonly ICoinCountReseter _reseter;

	  public RestartingService(ICoinCountReseter reseter) => 
		  _reseter = reseter;

	  public void Restart()
	  {
			_reseter.ResetCoinCount();

		  Restarted?.Invoke();
	  }
  }
}