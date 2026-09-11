using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersInputMng : MonoBehaviour
{
    private EventBus _inet;
    public void Init(EventBus totz)
    {
       _inet = totz; 
    }
        
    public void OnMovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inet.TriggerMove(context.ReadValue<Vector2>());
        }
        else
        {
            var zero = new Vector2 (0,0);
            _inet.TriggerMove(zero);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookinput = context.ReadValue<Vector2>();
        if (lookinput.sqrMagnitude >= 3)
        {
           // Debug.Log(lookinput);
           _inet.TriggerLook(lookinput);
        }
        else
        {
             _inet.TriggerLook(Vector2.zero);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inet.TriggerJump();
        }
    }

    public void OnDance(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inet.TriggerDance();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _inet.TriggerSprint(true);
        }
        if (context.canceled)
        {
            _inet.TriggerSprint(false);
        }
    }

     public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _inet.TriggerAttack(true);
        }
        if (context.canceled)
        {
            _inet.TriggerAttack(false);
        }
    }


  
}
