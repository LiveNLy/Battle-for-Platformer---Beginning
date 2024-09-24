using System;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private CharacterReseter _characterReseter;

    private int _collectedCoins = 0;

    public event Action<int> SendInfo;

    private void OnEnable()
    {
        _collisionHandler.CoinTaken += IncreaseCoinsCount;
        _characterReseter.CoinIndicatorReset += ResetCoins;
    }
    private void OnDisable()
    {
        _collisionHandler.CoinTaken -= IncreaseCoinsCount;
        _characterReseter.CoinIndicatorReset -= ResetCoins;
    }

    private void IncreaseCoinsCount()
    {
        _collectedCoins++;
        SendInfo?.Invoke(_collectedCoins);
    }

    private void ResetCoins()
    {
        _collectedCoins = 0;
        SendInfo?.Invoke(_collectedCoins);
    }
}
