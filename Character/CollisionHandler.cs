using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action CoinTaken;
    public event Action MedKitTaken;
    public event Action LosingHealth;
    public event Action LosedHeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            CoinTaken?.Invoke();
        }
        else if (collision.gameObject.TryGetComponent(out MedKit medKit))
        {
            MedKitTaken?.Invoke();
        }
        else if (collision.gameObject.TryGetComponent(out DeathTrigger deathTrigger))
        {
            LosedHeath?.Invoke();
        }
        else if (collision.gameObject.TryGetComponent(out EnemyHitbox enemyHitbox))
        {
            LosingHealth?.Invoke();
        }
    }
}
