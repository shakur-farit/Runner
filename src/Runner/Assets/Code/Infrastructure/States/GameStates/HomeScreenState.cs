using Code.Infrastructure.States.Infrastructure;
using Code.Meta.Ui.Windows;
using Code.Meta.Ui.Windows.Factory;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
	public class HomeScreenState : IState
	{
		private readonly IWindowService _windowService;

		public HomeScreenState(IWindowService windowService) => 
			_windowService = windowService;

		public void Enter() => 
			_windowService.Open(WindowId.MainMenuWindow);

		public void Exit()
		{
		}
	}
}