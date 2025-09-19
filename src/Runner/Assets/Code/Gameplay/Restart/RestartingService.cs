using System;
using Assets.Code.Gameplay.Loot.Service;

namespace Assets.Code.Gameplay.Restart
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