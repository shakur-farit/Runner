using System;

namespace Code.Infrastructure.Installers
{
	public class CoinService : ICoinService, ICoinCountReseter
	{
		public event Action Changed;

		public int Coin { get; private set; }

		public void ChangeCoinCount(int value)
		{
			Coin += value;
			Changed?.Invoke();
		}

		public void ResetCoinCount() => 
			Coin = 0;
	}
}