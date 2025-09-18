using Code.Infrastructure.States.Infrastructure;
using Code.Meta.Ui.Windows;
using Code.Meta.Ui.Windows.Factory;

namespace Code.Infrastructure.States.GameStates
{
	public class LevelCompleteState : IState
	{
    private readonly IWindowService _windowService;

    public LevelCompleteState(IWindowService windowService) =>
      _windowService = windowService;

    public void Enter() => 
      _windowService.Open(WindowId.LevelCompleteWindow);

    public void Exit()
		{
		}
	}
}