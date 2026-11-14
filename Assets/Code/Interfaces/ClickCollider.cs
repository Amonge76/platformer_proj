using UnityEngine;

public class ClickCollider : MonoBehaviour
{
    [SerializeField] private Transform _rayOrigin;
    [SerializeField] private float _rayDistance = 0.1f;
    [SerializeField] private LayerMask _interactebleLayers;

    public Iinteractable CurrentInteractable {get; private set;}

    public bool HasInteractable => CurrentInteractable != null;

    private void Update()
    {
        CheckForInteractables();
    }

    private void CheckForInteractables()
    {
        Vector2 origin = _rayOrigin != null ? _rayOrigin.position : transform.position;
        Vector2 direction = _rayOrigin != null ? _rayOrigin.right : transform.right;
        Collider2D[] hits = Physics2D.OverlapCircleAll(origin, _rayDistance, _interactebleLayers);

        CurrentInteractable = null;
        if(hits.Length > 0 && hits[0].TryGetComponent(out Iinteractable interactable))
        {
            CurrentInteractable = interactable;
        }
        else
        {
            CurrentInteractable = null;
        }

        Debug.DrawRay(origin, direction * _rayDistance, HasInteractable ? Color.green : Color.red);
    }
}
