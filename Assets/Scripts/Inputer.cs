using System;
using UnityEngine;

public class Inputer : MonoBehaviour
{
    const string jumpMove = "Jump";
    const string horizontalMove = "Horizontal";
    public event Action Jump;
    public event Action<float> Move;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw(horizontalMove);

        if (Input.GetButtonDown(jumpMove))
            Jump?.Invoke();

        Move?.Invoke(horizontal);
    }
}
