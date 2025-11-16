using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Inputer _inputer;
    [SerializeField] private Animator _animator;

    private static readonly int IsRunningHash = Animator.StringToHash("isRunning");

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
        _animator.SetBool(IsRunningHash, Mathf.Abs(speed) > 0);
    }
}
