using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    private TextMeshProUGUI _text;
    private int _prevScore;
    
    public static int Score;

    private void Start() {
        Score = 0;
        _prevScore = 0;
        _text = GetComponent<TextMeshProUGUI>();
    }


    private void Update() {
        
        if (_prevScore == Score) return;
        _text.SetText("<sprite=0> " + Score);
        _prevScore = Score;
    }
}