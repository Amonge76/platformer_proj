using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class playerControler : MonoBehaviour
{
    private EventBus _inet;
    [SerializeField] private PlayerMoveController _playerMoveController;
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundLayer;

    private float _timer = 0f;
    private float _checkDelay = 0.2f;
    private float _checkDistance = 0.2f;
    private bool _isGrounded = false;

    private void OnEnable()
    {
      _inet = GameManager.Instance.Inet;
      _inet._onMoveCallBack += OnMovePressed;
      _inet._onJump += OnJumpPressed;
    }

     private void OnDisable()
    {
      _inet._onMoveCallBack -= OnMovePressed;
      _inet._onJump -= OnJumpPressed;
    }

    private void FixedUpdate()
    {
      _timer += Time.fixedDeltaTime;
      if(_timer >= _checkDelay)
      {
        CheckForGround();
        _timer = 0;
      }
      
    }

    private void OnMovePressed(Vector2 moveInput)
    { 
       _playerMoveController.OnMovePressed(moveInput);
    }

    private void OnLookPressed(Vector2 lookinput)
    {
        _playerMoveController.OnMovePressed(lookinput);
    }

    private void OnJumpPressed()
    {
        _playerMoveController.OnJumpPressed();
    }

    private void CheckForGround()
    {
        if(Physics2D.Raycast(_legs.position, Vector2.down, _checkDistance, _groundLayer))
        {
            if(!_isGrounded)
           {
              _isGrounded = true;
           }
        }
        else
        {
            if(_isGrounded)
            {
                _isGrounded = false;
            }
        }
        NotifyGrounded();
    }

    private void NotifyGrounded()
    {
      _playerMoveController.SetGrounded(_isGrounded);
    }
}
    

    

    

