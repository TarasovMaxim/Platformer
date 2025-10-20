using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Inputer _inputer;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _inputer.Move += Move;
    }

    private void OnDisable()
    {
        _inputer.Move -= Move;
    }

    private void Move(float speed)
    {

        if (Mathf.Abs(speed) != 0)
            _animator.SetBool("isRunning", true);
        else
            _animator.SetBool("isRunning", false);
    }
}
