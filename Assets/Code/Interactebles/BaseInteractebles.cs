using System;
using UnityEngine;

public abstract class BaseInteractebles : MonoBehaviour, Iinteractable
{

    protected bool _isInteracting = false;
    [SerializeField] protected BoxCollider2D _boxCollider;

    public void Interact(GameObject interactor)//; 
    {
        OnInteract(interactor);
    }
    public bool CanInteract(GameObject interactor)
    {
        return _isInteracting;
    }

    protected virtual void OnInteract(GameObject ineractor)
    {
        Debug.Log($" Interacted with {gameObject.name}");
    }
}
