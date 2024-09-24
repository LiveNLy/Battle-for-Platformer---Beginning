using System;
using UnityEngine;

public class MedKitIntermediary : MonoBehaviour
{
    [SerializeField] private MedKit[] _medKits;
    [SerializeField] private Character _character;

    public event Action<int> Healing;

    private void Heal(int healAmount)
    {
        Healing?.Invoke(healAmount);
    }

    private void OnEnable()
    {
        for (int i = 1; i <= _medKits.Length; i++)
        {
            _medKits[i - 1].MedKitTaken += Heal;
        }
    }

    private void OnDisable()
    {
        for (int i = 1; i <= _medKits.Length; i++)
        {
            _medKits[i - 1].MedKitTaken -= Heal;
        }
    }
}