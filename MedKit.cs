using System;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    private int _healthHealing = 40;

    public event Action<int> MedKitTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollisionHandler collisionHandler))
        {
            MedKitTaken?.Invoke(_healthHealing);
            gameObject.SetActive(false);
        }
    }
}