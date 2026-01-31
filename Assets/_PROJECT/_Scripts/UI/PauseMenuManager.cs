using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private PauseMenuButtons _pauseUI;
    [SerializeField] private PlayerController _player;
    [SerializeField] private string _startScreen = "StartScreen Test Dodo";
    private void Awake()
    {
        _pauseUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    
    private void OnEnable()
    {
        _pauseUI.OnClickResume += HandleResumeClicked;
        _pauseUI.OnClickRestart += HandleRestartClicked;
        _pauseUI.OnClickBacktoMenu += HandleBackClicked;
        _player.OnPauseClicked += HandlePauseClicked;
    }

    private void OnDisable()
    {
        _pauseUI.OnClickResume -= HandleResumeClicked;
        _pauseUI.OnClickRestart -= HandleRestartClicked;
        _pauseUI.OnClickBacktoMenu -= HandleBackClicked;
        _player.OnPauseClicked -= HandlePauseClicked;
    }

    private void HandleResumeClicked()
    {
        Time.timeScale = 1;
        _pauseUI.gameObject.SetActive(false);
    }

    private void HandleRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HandleBackClicked()
    {
        SceneManager.LoadScene(_startScreen);
    }

private void HandlePauseClicked()
{
    bool isPaused = !_pauseUI.gameObject.activeSelf;

    _pauseUI.gameObject.SetActive(isPaused);
    Time.timeScale = isPaused ? 0f : 1f;
}

}
