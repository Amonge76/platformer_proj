using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class playerControler : MonoBehaviour
{
    private EventBus _inet;
    [SerializeField] private PlayerMoveController _playerMoveController;

    private void OnEnable()
    {
      _inet = GameManager.Instance.Inet;
      _inet._onMoveCallBack += OnMovePressed;
      
    }

     private void OnDisable()
    {
      _inet._onMoveCallBack -= OnMovePressed;
    }

   private void OnMovePressed(Vector2 moveInput)
    { 
       _playerMoveController.OnMovePressed(moveInput);
    }

    private void OnLookPressed(Vector2 look)
    {
        
    }

    

    

    
}
