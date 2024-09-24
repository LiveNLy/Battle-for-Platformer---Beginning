using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinReleasing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character) || collision.gameObject.TryGetComponent(out EnemyHitbox enemyHitbox))
        {
            CoinReleasing?.Invoke(this);
        }
    }
}