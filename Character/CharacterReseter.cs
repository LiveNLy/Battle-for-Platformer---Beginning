using System;
using UnityEngine;

public class CharacterReseter : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Health _health;

    public event Action CoinIndicatorReset;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void ResetCharacter()
    {
        gameObject.transform.position = _startPosition;
        CoinIndicatorReset?.Invoke();
    }

    private void OnEnable()
    {
        _health.LostHeath += ResetCharacter;
    }

    private void OnDisable()
    {
        _health.LostHeath -= ResetCharacter;
    }
}
