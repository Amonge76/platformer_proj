using UnityEngine;

public interface Iinteractable
{
    public void Interact(GameObject interactor);
    public bool CanInteract(GameObject interactor);
}
