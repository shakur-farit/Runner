using System;

namespace Assets.Code.Gameplay.Loot.Service
{
	public interface ICoinService
	{
		event Action Changed;
		int Coin { get; }
		void ChangeCoinCount(int value);
	}
}