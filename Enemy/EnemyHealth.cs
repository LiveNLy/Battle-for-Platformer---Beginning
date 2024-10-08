using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private EnemyHurtBox _enemyHurtBox;

    private float _losedHealthByHit = 45f;


    private void OnEnable()
    {
        _enemyHurtBox.LosedHealth += LoseHealth;
    }

    private void FixedUpdate()
    {
        if (_health <= 0)
        {
            gameObject.SetActive(false);
            _health = 100;
        }
    }

    private void OnDisable()
    {
        _enemyHurtBox.LosedHealth -= LoseHealth;
    }

    private void LoseHealth()
    {
        _health -= _losedHealthByHit;
    }
}
