using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour {
    private TextMeshProUGUI _text;

    public static int Coins;

    private int _prevCoins;

    void Start() {
        Coins = 0;
        _prevCoins = 0;
        _text = GetComponent<TextMeshProUGUI>();
    }


    public void Update() {
        if (_prevCoins == Coins) return;
        _text.SetText("<sprite=1> " + Coins);
        _prevCoins = Coins;
    }
}