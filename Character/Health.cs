using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private CollisionHandler _collisionHandler;

    private float _losedHealthByHit = 20f;
    private float _healFromMed = 40f;

    public event Action LostHeath;

    private void OnEnable()
    {
        _collisionHandler.MedKitTaken += Heal;
        _collisionHandler.LosingHealth += LoseHealth;
        _collisionHandler.LosedHeath += Death;
    }

    private void FixedUpdate()
    {
        if (_health <= 0)
        {
            ResetHealth();
        }
    }

    private void OnDisable()
    {
        _collisionHandler.MedKitTaken -= Heal;
        _collisionHandler.LosingHealth -= LoseHealth;
        _collisionHandler.LosedHeath -= Death;
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

    private void Heal()
    {
        _health += _healFromMed;
    }

    private void Death()
    {
        _health = 0;
    }
}