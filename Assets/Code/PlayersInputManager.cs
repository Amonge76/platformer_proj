using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersInputMng : MonoBehaviour
{
    public static event Action<Vector2> _onMoveCallBack;
    public static event Action<Vector2> _onLookCallBack;
    public static event Action _onDance;
    public static event Action _onJump;

    public static event Action<bool> _onShoot;

    public void OnMovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _onMoveCallBack?.Invoke(context.ReadValue<Vector2>());
        }
        else
        {
            var zero = new Vector2 (0,0);
            _onMoveCallBack?.Invoke(zero);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookinput = context.ReadValue<Vector2>();
        if (lookinput.sqrMagnitude >= 3)
        {
           // Debug.Log(lookinput);
            _onLookCallBack?.Invoke(lookinput);
        }
        else
        {
            Vector3 zero = new Vector2(0,0);
            _onLookCallBack?.Invoke(zero);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _onJump?.Invoke();
        }
    }

    public void OnDance(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _onDance?.Invoke();
        }
    }


    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _onShoot?.Invoke(true);
        }
        if(context.canceled)
        {
            _onShoot?.Invoke(false);
        }
    }
}
