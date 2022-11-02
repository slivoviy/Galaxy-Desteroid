using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneButtons : MonoBehaviour {
    [SerializeField] private Animator pauseAnim;
    [SerializeField] private GameObject pauseMenuUI;
    
    private static readonly int IsOpened = Animator.StringToHash("IsOpened");

    public void Pause() {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        pauseAnim.SetBool(IsOpened, true);
    }

    public void Resume() {
        StartCoroutine(CloseMenu());
    }

    public void GoToMainMenu() {
        StartCoroutine(LoadScene("MainMenuScene"));
    }

    private IEnumerator CloseMenu() {
        pauseAnim.SetBool(IsOpened, false);

        yield return new WaitForSecondsRealtime(0.667f);

        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);
    }

    private IEnumerator LoadScene(string scene) {
        pauseAnim.SetBool(IsOpened, false);

        yield return new WaitForSecondsRealtime(0.667f);

        Time.timeScale = 1f;

        SceneManager.LoadScene(scene);
    }
}