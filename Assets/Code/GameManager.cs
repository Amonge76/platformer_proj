
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventBus _inet;
    [SerializeField] private PlayersInputMng _inputMng;
    private EventBus Inet => _inet;
    public static GameManager Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
        DontDestroyOnLoad(this);
        _inputMng.Init(_inet);

        SceneManager.LoadScene(SceneList._mainScene);
    }


}
