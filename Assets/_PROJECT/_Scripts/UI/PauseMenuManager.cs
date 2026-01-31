using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private PauseMenuButtons _pauseUI;

    private void Awake()
    {
        _pauseUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseUI.gameObject.SetActive(!_pauseUI.gameObject.activeSelf);
        }
    }
    private void OnEnable()
    {
        _pauseUI.OnClickResume += HandleResumeClicked;
        _pauseUI.OnClickRestart += HandleRestartClicked;
        _pauseUI.OnClickBacktoMenu += HandleBackClicked;
    }

    private void OnDisable()
    {
        _pauseUI.OnClickResume -= HandleResumeClicked;
        _pauseUI.OnClickRestart -= HandleRestartClicked;
        _pauseUI.OnClickBacktoMenu -= HandleBackClicked;
    }

    private void HandleResumeClicked()
    {
        Time.timeScale = 1;
        _pauseUI.gameObject.SetActive(false);
    }

    private void HandleRestartClicked()
    {
        
    }

    private void HandleBackClicked()
    {
        
    }
}
