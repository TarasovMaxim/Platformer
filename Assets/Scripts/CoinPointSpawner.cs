using UnityEngine;
using System.Collections;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private float _respawnDelay = 3f;

    private GameObject _currentCoin;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (enabled)
        {
            if (_currentCoin == null)
            {
                _currentCoin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(_respawnDelay);
            }

            yield return null;
        }
    }
}
