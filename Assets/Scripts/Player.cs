using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Inputer _inputer;
    [SerializeField] private float _speed = 5.5f;
    private bool _isFaceRight = true;
    private bool _CanJump = true;
    public int CoinsCollected { get; private set; }

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
        _CanJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _CanJump= false;
    }

    public void CollectCoin()
    {
        CoinsCollected++;
    }

    private void Move(float horizontal)
    {
        Flip(horizontal);
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * _speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && _isFaceRight==false)
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
        if ( _CanJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
        }
    }
}
