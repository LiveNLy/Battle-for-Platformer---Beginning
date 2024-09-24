using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private MedKitIntermediary _medKitIntermediary;

    private float _losedHealthByHit = 20f;

    public event Action LostHeath;

    private void FixedUpdate()
    {
        if (_health <= 0)
        {
            ResetHealth();
        }
    }

    private void ResetHealth()
    {
        _health = 100;
        LostHeath?.Invoke();
    }

    private void LoseHealth()
    {
        _health -= _losedHealthByHit;
    }

    private void Heal(int heal)
    {
        _health += heal;
    }

    private void Death()
    {
        _health = 0;
    }

    private void OnEnable()
    {
        _medKitIntermediary.Healing += Heal;
        _collisionHandler.LosingHealth += LoseHealth;
        _collisionHandler.LosedHeath += Death;
    }

    private void OnDisable()
    {
        _medKitIntermediary.Healing -= Heal;
        _collisionHandler.LosingHealth -= LoseHealth;
        _collisionHandler.LosedHeath -= Death;
    }
}