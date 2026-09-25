using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private const string _moveParameter = "MoveSpeed";

    

    public void UpdateAnimation(float currentSpeed)
    {
       if(_playerAnimator == null)
       return;
       
        _playerAnimator.SetFloat(_moveParameter, currentSpeed);
    }
}
