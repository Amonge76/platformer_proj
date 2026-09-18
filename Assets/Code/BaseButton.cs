using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseButton : MonoBehaviour
{
    [SerializeField] private ButtonType _buttonType;
    [SerializeField] private Button _button;

    private EventBus _eventBus;

    private void OnEnable()
    {
        _eventBus = GameManager.Instance.Inet;
        _button.onClick.AddListener(OnClick);
        
    }

    private void OnDisable()
    {
         _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _eventBus.TriggerButton(_buttonType);
    }
   
}
