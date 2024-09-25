using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private CoinSpawner _spawnPosition;
    [SerializeField] private float _repeatRate = 0.5f;
    [SerializeField] private int _poolDefaultCapacity = 5;
    [SerializeField] private int _poolMaxSize = 12;

    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            actionOnGet: (coin) => SetCoin(coin),
            createFunc: () => Instantiate(_coinPrefab),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnDestroy: (coin) => Destroy(coin),
            collectionCheck: true,
            defaultCapacity: _poolDefaultCapacity,
            maxSize: _poolMaxSize);
    }

    private void OnEnable()
    {
        _coinPrefab.CoinReleasing += ReleaseCoin;
    }

    private void Start()
    {
        StartCoroutine(SpawnCoin(_repeatRate));
    }

    private void OnDisable()
    {
        _coinPrefab.CoinReleasing -= ReleaseCoin;
    }

    private void ReleaseCoin(Coin coin)
    {
        _pool.Release(coin);
        coin.CoinReleasing -= ReleaseCoin;
    }

    private void GetCoin()
    {
        _pool.Get();
    }

    private void SetCoin(Coin coin)
    {
        coin.transform.position = SetRandomPosition();
        coin.gameObject.SetActive(true);
        coin.CoinReleasing += ReleaseCoin;
    }

    private Vector2 SetRandomPosition()
    {
        Vector2 position = _spawnPosition.transform.position;
        float minRandom = -20f;
        float maxRandom = 20f;

        position.x = _spawnPosition.transform.position.x - Random.Range(minRandom, maxRandom);

        return position;
    }

    private IEnumerator SpawnCoin(float seconds)
    {
        var wait = new WaitForSeconds(seconds);

        while (enabled)
        {
            GetCoin();
            yield return wait;
        }
    }
}
