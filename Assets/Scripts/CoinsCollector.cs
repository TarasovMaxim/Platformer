using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private int _coins;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Coin coin = collider.GetComponent<Coin>();

        if (coin != null)
        {
            _coins++;
            Destroy(coin.gameObject);
        }
    }
}