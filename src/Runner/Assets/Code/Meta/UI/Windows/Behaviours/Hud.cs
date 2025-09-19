using Assets.Code.Gameplay.Loot.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Meta.UI.Windows.Behaviours
{
	public class Hud : BaseWindow
	{
		[SerializeField] private TextMeshProUGUI _coinText;

		private ICoinService _coinService;

		[Inject]
		public void Constructor(ICoinService coinService)
		{
			Id = WindowId.Hud;

			_coinService = coinService;
		}

		protected override void SubscribeUpdates() =>
			_coinService.Changed += UpdateCoinText;

		protected override void UnsubscribeUpdates() => 
			_coinService.Changed -= UpdateCoinText;

		private void UpdateCoinText() => 
			_coinText.text = _coinService.Coin.ToString();
	}
}