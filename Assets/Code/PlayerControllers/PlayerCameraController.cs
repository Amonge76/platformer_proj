using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCameraController : MonoBehaviour
{
    private EventBus _inet;
    private Vector3 _targetPosition;
    [SerializeField] private Vector3 _offset = new Vector3(0, 1, -10);

    public void Initialize(EventBus bus)
    {
        _inet = bus;
    }

    public void GetPlayerPosition(Vector3 position)
    {
        _targetPosition = position + _offset;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, 0.1f);
    }
}
