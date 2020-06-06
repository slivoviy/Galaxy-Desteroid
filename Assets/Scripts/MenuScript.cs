using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour {
    public Text maxDestroyed;
    public TextMeshProUGUI coins;
    
    private int _score;
    private int _coins;

    void Start() {
        _score = PlayerPrefs.GetInt("score", 0);
        _coins = PlayerPrefs.GetInt("coins", 0);
        
        maxDestroyed.text = "Max Destroyed: " + _score;
        coins.SetText("<sprite=1> " + _coins);
    }

    public void Play() {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit() {
        Application.Quit();
    }
}