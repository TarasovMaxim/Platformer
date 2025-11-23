using UnityEngine;
using System.Collections;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _respawnDelay = 3f;

    private Coin _currentCoin;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        var delay = new WaitForSeconds(_respawnDelay);

        while (enabled)
        {
            if (_currentCoin == null)
            {
                _currentCoin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
                yield return delay;
            }

            yield return null;
        }
    }
}
