using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        float delay = 3f;
        float delta = 8f;

        while (enabled)
        {
            _rigidBody.velocity = new Vector2(delta, _rigidBody.velocity.y);

            delta = -delta;
            yield return new WaitForSeconds(delay);
        }
    }
}
