using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

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
            GetComponent<Rigidbody2D>().velocity = new Vector2(delta, GetComponent<Rigidbody2D>().velocity.y);
            delta = -delta;
            yield return new WaitForSeconds(delay);
        }
    }
}
