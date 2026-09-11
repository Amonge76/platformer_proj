using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    [SerializeField] private ButtonType _buttonType;
    [SerializeField] private Button _button;

    private EventBus _eventBus;

    private void OnEnable()
    {
        _eventBus = GameManager.Instance.Inet;
    }

    private void OnDisable()
    {
        
    }

    private void OnClick()
    {
        _eventBus.TriggerButton(_buttonType);
    }
}
