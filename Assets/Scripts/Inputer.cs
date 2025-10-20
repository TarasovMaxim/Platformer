using System;
using UnityEngine;

public class Inputer : MonoBehaviour
{
    public event Action Jump;
    public event Action<float> Move;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
            Jump?.Invoke();

        Move?.Invoke(horizontal);
    }
}
