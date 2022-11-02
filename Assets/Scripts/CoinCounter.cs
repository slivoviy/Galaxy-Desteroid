using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour {
    private TextMeshProUGUI _text;
    private int _prevCoins;

    public static int Coins;

    private void Start() {
        Coins = 0;
        _prevCoins = 0;
        _text = GetComponent<TextMeshProUGUI>();
    }


    private void Update() {
        if (_prevCoins == Coins) return;
        _text.SetText("<sprite=1> " + Coins);
        _prevCoins = Coins;
    }
}