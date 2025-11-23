using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public bool IsFaceRight { get; private set; } = true;

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
        float distance = 8f;
        float stopDistance = 0.05f;
        float speed = 2f;

        Vector2 position1 = new Vector2(transform.position.x + distance, transform.position.y);
        Vector2 position2 = new Vector2(transform.position.x - distance, transform.position.y);
        List<Vector2> positions = new List<Vector2> { position1, position2 };

        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while (enabled)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                Vector2 target = positions[i];

                while (((Vector2)transform.position - target).sqrMagnitude > stopDistance * stopDistance)
                {
                    Vector2 newPos = Vector2.MoveTowards(_rigidBody.position, target, speed * Time.fixedDeltaTime);
                    _rigidBody.MovePosition(newPos);
                    yield return waitForFixedUpdate;
                }
            }
        }
    }
}