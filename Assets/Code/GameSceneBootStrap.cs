using UnityEngine;

public class GameSceneBootStrap : MonoBehaviour
{
    [SerializeField] private PlayerCameraController _plrCamera;
    [SerializeField] private playerControler _plrControler;
    private EventBus _inet;

    private void Awake()
    {
        _inet = GameManager.Instance.Inet;
        _plrCamera.Initialize(_inet);
        _plrControler.Initialize(_plrCamera, _inet);
    }
}
