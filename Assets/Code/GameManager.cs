using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Purchasing;

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




    }
}
