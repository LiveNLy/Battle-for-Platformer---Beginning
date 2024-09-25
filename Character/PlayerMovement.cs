using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Running = nameof(Running);
    private const string Jumping = nameof(Jumping);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _canJump = true;
    [SerializeField] private float _jumpPower;

    private Animator _animator;
    private Fliper _fliper;
    private Rigidbody2D _rigidbody;
    private float _direction = 0f;
    private bool _flipped = true;
    private bool _isJump;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _fliper = GetComponent<Fliper>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        float distance = _direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);

        if (_isJump)
        {
            _rigidbody.velocity = _jumpPower * Vector2.up;
            _canJump = false;
            _isJump = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _canJump)
        {
            _animator.SetTrigger(Jumping);
            _isJump = true;
        }
    }

    private void Move()
    {
        _direction = Input.GetAxis(Horizontal);
        float distance = _direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);

        _animator.SetBool(Running, IsCharacterMoving());

        if (_direction > 0 && !_flipped || _direction < 0 && _flipped)
        {
            _fliper.Flip();
            _flipped = !_flipped;
        }
    }

    private bool IsCharacterMoving() => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground platform))
            _canJump = true;
    }
}