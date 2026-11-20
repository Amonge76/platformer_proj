using System;
using DG.Tweening;
using UnityEngine;

public class Door : BaseInteractebles
{
    [SerializeField] private float _openAngle = 90f;
    [SerializeField] private float _openSpeed = 0.2f;
    
    private Tween _openTween;
    private Vector3 _defaultRotation;
    private bool _isOpen = false;
    protected override void OnInteract(GameObject ineractor)
    {
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        _isOpen = !_isOpen;
        _boxCollider.isTrigger = _isOpen;
        AnimateDoor();
    }

    private void AnimateDoor()
    {
        if (_openTween != null)
        {
            _openTween.Kill();
        }

        float targetAngle = _isOpen ? _openAngle : 0f;
        _openTween = transform.DORotate(new Vector3(0f,targetAngle, 0f), _openSpeed).SetEase(Ease.InOutSine);
    }
}
