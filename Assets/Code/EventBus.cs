using System;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.InputSystem;

public class EventBus : MonoBehaviour
{
    public event Action<Vector2> _onMoveCallBack;
    public event Action<Vector2> _onLookCallBack;
    public event Action _onDance;
    public event Action _onJump;
    public event Action<bool> _onSprint;
    public event Action<bool> _onAttack;
    public event Action<ButtonType> _onButtonClick;
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

    public void TriggerAttack(bool andrey)
    {
        _onAttack?.Invoke(andrey);
    }

     public void TriggerSprint(bool danaya)
    {
        _onSprint?.Invoke(danaya);
    }

     public void TriggerButton(ButtonType buttonType)
    {
        _onButtonClick?.Invoke(buttonType);
    }

}
