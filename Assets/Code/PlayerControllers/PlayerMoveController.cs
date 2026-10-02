using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _walkspeed;
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    
    private bool _isGrounded = false;
    private float currentSpeed;
    private Vector2 _currentMoveVector;



    private void FixedUpdate()
    {
        Move();
        
    }

    public void OnMovePressed(Vector2 moveInput)
    { 
        float moveX = moveInput.x;
       _currentMoveVector = transform.right * moveX;
     }

     private void Move()
    {

        if (_currentMoveVector.sqrMagnitude > 0.01f)
        {
            currentSpeed = _walkspeed;
        }
        else
        {
            currentSpeed = 0;
        }

        Vector2 move = _currentMoveVector * _walkspeed * Time.fixedDeltaTime;

        _playerAnimationController.UpdateAnimation(currentSpeed);
       // _playerRB.MovePosition(_playerRB.position + move);
       _playerRB.linearVelocity = new Vector2(move.x, _playerRB.linearVelocity.y);
    }

    public void OnJumpPressed()
    {
        if (!_isGrounded)
        {
            return;
        }
        _playerRB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void SetGrounded(bool grounded)
    {
        _isGrounded = grounded;
    }
}
