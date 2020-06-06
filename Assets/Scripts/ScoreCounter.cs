using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    private TextMeshProUGUI _text;
    
    public static int Score;

    private int _prevScore;
    
    void Start() {
        Score = 0;
        _prevScore = 0;
        _text = GetComponent<TextMeshProUGUI>();
    }


    public void Update() {
        
        if (_prevScore == Score) return;
        _text.SetText("<sprite=0> " + Score);
        _prevScore = Score;
    }
}