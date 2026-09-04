using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventBus : MonoBehaviour
{
    public event Action<Vector2> _onMoveCallBack;
    public event Action<Vector2> _onLookCallBack;
    public event Action _onDance;
    public event Action _onJump;

    public void TriggerMove(Vector2 kostya)
    {
        _onMoveCallBack?.Invoke(kostya);
    }

    public void TriggerLook(Vector2 artem)
    {
        _onLookCallBack?.Invoke(artem);
    }

     public void TriggerJump()
    {
        _onJump?.Invoke();
    }

     public void TriggerDance()
    {
        _onDance?.Invoke();
    }

}
