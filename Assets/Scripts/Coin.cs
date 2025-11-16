using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CoinsCollector coinsCollector = collider.GetComponent<CoinsCollector>();

        if (coinsCollector != null)
        {
            coinsCollector.CollectCoin();
            Destroy(_coinPrefab);
        }
    }
}