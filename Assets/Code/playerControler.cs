using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class playerControler : MonoBehaviour
{
    [SerializeField] private PlayerCameraController _cameraController;
    [SerializeField] private PlayerAttackController _attackController;
  [SerializeField] private float _walkspeed;
  [SerializeField] private Rigidbody _playerRB;
  [SerializeField] private Animator _playerAnimator;
  [SerializeField] private AudioSource _playerFootsteps;
  [SerializeField] private float _lookspeed = 5f;
  [SerializeField] private float _jumpForce = 5f;

    private float _targetLookY;
    private bool _isGrounded = true;
  
  private float currentSpeed;
  private const string _moveParameter = "MoveSpeed";
  private const string _danceParameter = "Dance";
  private const string _groundTag = "Ground";
  private Vector3 _currentMoveVector;

    
    

    //private float _moveX = 0;
    //private float _moveZ = 0;


    private void OnEnable()
    {
        PlayersInputMng._onMoveCallBack += OnMovePressed;
        PlayersInputMng._onLookCallBack += OnLookPressed;
        PlayersInputMng._onJump += OnJumpPressed;
        PlayersInputMng._onDance += OnDancePressed;
        PlayersInputMng._onShoot += OnShoot;

    }

     private void OnDisable()
    {
        PlayersInputMng._onMoveCallBack -= OnMovePressed;
        PlayersInputMng._onLookCallBack -= OnLookPressed;
        PlayersInputMng._onJump -= OnJumpPressed;
        PlayersInputMng._onDance -= OnDancePressed;
        PlayersInputMng._onShoot -= OnShoot;
    }

   private void OnMovePressed(Vector2 moveInput)
    { 
        //Debug.Log(moveInput); 
        float moveX = moveInput.x; 
        float moveZ = moveInput.y; 
       _currentMoveVector = transform.forward * moveX + transform.right * moveZ;
     }

    private void OnLookPressed(Vector2 look)
    {
        _targetLookY = look.x;
        _cameraController.RotateCamera(look);
        
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void Rotate()
{
    Quaternion targetRotation = Quaternion.Euler(0f, _targetLookY * _lookspeed * Time.fixedDeltaTime, 0f);
    _playerRB.MoveRotation(_playerRB.rotation * targetRotation);
}
    private void Move()
    {

        if (_currentMoveVector.sqrMagnitude > 0.01f)
        {
            currentSpeed = _walkspeed;
             if (!_playerFootsteps.isPlaying)
             {
            _playerFootsteps.Play();
             }
        }
        else
        {
            currentSpeed = 0;
            if (_playerFootsteps.isPlaying)
            {
            _playerFootsteps.Stop();
            }
        }


        Vector3 move = _currentMoveVector * _walkspeed * Time.fixedDeltaTime;



        _playerRB.MovePosition(_playerRB.position + move);
    }

    private void UpdateAnimation()
    {
        _playerAnimator.SetFloat(_moveParameter, currentSpeed);
    }

    private void OnJumpPressed()
    {
        if (!_isGrounded)
        {
            return;
        }
        _playerRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_groundTag))
        {
            _isGrounded = true;
        }
    }

    private void OnDancePressed()
    {
        _playerAnimator.SetTrigger(_danceParameter);
    }

    private void OnShoot(bool t)
{
    _attackController.OnShootPerformed(t);
    Debug.Log($"Attack {t}");
}
}
