using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        CoinsCollector coinsCollector = collider.GetComponent<CoinsCollector>();

        if (coinsCollector != null)
        {
            coinsCollector.CollectCoin();
            Destroy(gameObject);
        }
    }
}