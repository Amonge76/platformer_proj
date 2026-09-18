
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventBus _inet;
    [SerializeField] private PlayersInputMng _inputMng;
    public EventBus Inet => _inet;
    public static GameManager Instance {get; private set;}
    
    private GameState _gameState = GameState.System;
    public GameState GameState => _gameState;

    private void Awake()
    {

        if(Instance != null)
        {
            Destroy(this);
        }
    
        Instance = this;
   
        DontDestroyOnLoad(this);

        _inputMng.Init(_inet);
        _inet._onButtonClick += OnUIButton;

        OnStateRequest(GameState.MainMenu);
    }

    private void OnUIButton(ButtonType type)
    {
        switch(type)
        {
            case ButtonType.Start:
            OnStateRequest(GameState.Playing);
            break;

            case ButtonType.MainMunu:
            OnStateRequest(GameState.Playing);
            break;

            case ButtonType.Exit:
            Application.Quit();
            break;
        }
    }

    private void OnStateRequest(GameState state)
    {
        if(_gameState == state) return;

        switch(state)
        {
            case GameState.Playing:
            LoadToScene(SceneList._gameScene);
            break;

            case GameState.MainMenu:
            LoadToScene(SceneList._mainScene);
            break;

            case GameState.Paused:
            if(_gameState == GameState.GameOver || _gameState == GameState.MainMenu) return;
            break;

            case GameState.GameOver:
            
            break;

        }

        _gameState = state;
    }

    private void LoadToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}

public enum GameState
{
    Playing,
    Paused,
    MainMenu,
    GameOver,
    System,

}