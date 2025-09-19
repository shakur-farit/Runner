using System;

namespace Code.Infrastructure.Installers
{
	public interface ICoinService
	{
		event Action Changed;
		int Coin { get; }
		void ChangeCoinCount(int value);
	}
}