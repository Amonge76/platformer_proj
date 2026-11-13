using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    public UiState CurrentState {get; private set;} = UiState.Systems;
    private EventBus _inet;

    public void Init(EventBus Inet)
    {
        _inet = Inet;
        _inet._onButtonClick += OnUiButton;
        _inet._onGameStateRequest += OnGameStateChanged;
    }

    private void OnUiButton(ButtonType button)
    {
        switch(button)
        {
            case ButtonType.Start:
            _inet.RequestGameState(GameState.Playing);
            break;

            case ButtonType.MainMunu:
            ChangeState(UiState.MainMenu);
            break;

            case ButtonType.Exit:
            Application.Quit();
            break;

            case ButtonType.Setting:
            //
            break;
        }
    }

    private void ChangeState(UiState newState)
    {
        if(CurrentState == newState) return;
        switch(newState)
        {
            case UiState.Playing:
            //
            break;

             case UiState.MainMenu:
            //
            break;

             case UiState.Pause:
            //
            break;

             case UiState.GameOver:
            //
            break;
        }
        CurrentState = newState;
    }

    private void Oestroy()
    {
        if(_inet != null)
        {
            _inet._onButtonClick -= OnUiButton;
        }
    }

    private void OnGameStateChanged(GameState newState)
    {
        switch(newState)
        {
            case GameState.Playing:
            ChangeState(UiState.Playing);
            break;

            case GameState.MainMenu:
            ChangeState(UiState.MainMenu);
            break;

            case GameState.Paused:
            ChangeState(UiState.Pause);
            break;

            case GameState.GameOver:
            ChangeState(UiState.GameOver);
            break;
        }
    }


}


public enum UiState
{
    Systems,
    MainMenu,
    Playing,
    Pause,
    GameOver,

}
