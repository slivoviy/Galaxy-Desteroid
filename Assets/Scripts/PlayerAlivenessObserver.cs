using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAlivenessObserver : MonoBehaviour {
    public GameObject player;
    
    void Update() {
        if (!player.activeInHierarchy) {
            
            StartCoroutine(ExitGame());
        }
    }

    private IEnumerator ExitGame() {
        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene("MainMenuScene");
    }
}