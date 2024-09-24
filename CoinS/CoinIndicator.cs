using TMPro;
using UnityEngine;

public class CoinIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Bag _bag;

    private void OnEnable()
    {
        _bag.SendInfo += ShowCoins;
    }

    private void OnDisable()
    {
        _bag.SendInfo -= ShowCoins;
    }

    private void ShowCoins(int coinsCount)
    {
        _text.text = "coins: " + coinsCount;
    }
}
