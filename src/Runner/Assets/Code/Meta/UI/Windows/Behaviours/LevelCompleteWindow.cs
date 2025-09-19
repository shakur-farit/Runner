using Code.Infrastructure.Installers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.Ui.Windows.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.Ui.Windows.Behaviours
{
  public class LevelCompleteWindow : BaseWindow
  {
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TextMeshProUGUI _coinText;

		private IGameStateMachine _stateMachine;
    private IWindowService _windowService;
    private IRestartingService _restarting;
    private ICoinService _coinService;

		[Inject]
    public void Constructor(
	    IGameStateMachine stateMachine, 
	    IWindowService windowService, 
	    IRestartingService restarting, 
	    ICoinService coinService)
    {
      Id = WindowId.LevelCompleteWindow;

      _stateMachine = stateMachine;
      _windowService = windowService;
      _restarting = restarting;
      _coinService = coinService;
		}

    protected override void Initialize()
    {
      _restartButton.onClick.AddListener(EnterToBattle);
      _quitButton.onClick.AddListener(QuitGame);

      UpdateCoinText();
    }

    private void UpdateCoinText() =>
	    _coinText.text = _coinService.Coin.ToString();

		private void EnterToBattle()
    {
      CloseWindow();
      _restarting.Restart();
      _stateMachine.Enter<LoadingGameplaySceneState, string>(Scenes.Gameplay);
    }

    private void QuitGame()
    {
      CloseWindow();

#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    private void CloseWindow() =>
      _windowService.Close(WindowId.LevelCompleteWindow);
  }
}