using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Inputer _inputer;
    [SerializeField] private float _speed = 5.5f;
    [SerializeField] private CoinsCollector _coinsCollector;
    private bool _ñanJump = true;
    private bool _isFaceRight = true;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
         _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputer.Jump += Jump;
        _inputer.Move += Move;
    }

    private void OnDisable()
    {
        _inputer.Jump -= Jump;
        _inputer.Move -= Move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ñanJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _ñanJump = false;
    }


    private void Move(float horizontal)
    {
        Flip(horizontal);
        _rigidbody2D.velocity = new Vector2(horizontal * _speed, _rigidbody2D.velocity.y);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && _isFaceRight == false)
        {
            _isFaceRight = true;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (horizontal < 0 && _isFaceRight)
        {
            _isFaceRight = false;
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void Jump()
    {
        if (_ñanJump)
        {
            _rigidbody2D.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
        }
    }
}