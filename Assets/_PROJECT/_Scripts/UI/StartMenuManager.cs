using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public static event Action OnControlMenuOpened;
    public static event Action OnReturnedToTitle;

    [SerializeField] private StartMenuButtons _startUI;
    [SerializeField] private GameObject _backButton;

    private void Awake()
    {
        // Back button hidden at start
        _backButton.SetActive(false);
    }

    private void OnEnable()
    {
        _startUI.OnClickStart += HandleStartClicked;
        _startUI.OnClickControl += HandleControlClicked;
        _startUI.OnClickQuit += HandleQuitClicked;
        _startUI.OnClickBack += HandleBackClicked;
    }

    private void OnDisable()
    {
        _startUI.OnClickStart -= HandleStartClicked;
        _startUI.OnClickControl -= HandleControlClicked;
        _startUI.OnClickQuit -= HandleQuitClicked;
        _startUI.OnClickBack -= HandleBackClicked;
    }

    private void HandleStartClicked()
    {
        _startUI.gameObject.SetActive(false);
        PlayTransitionCutscene();
    }

    private void HandleControlClicked()
    {
        _startUI.gameObject.SetActive(false);
        _backButton.SetActive(true);

        OnControlMenuOpened?.Invoke();
        Debug.Log("Open Controls Menu");
    }

    private void HandleBackClicked()
    {
        _startUI.gameObject.SetActive(true);
        _backButton.SetActive(false);

        OnReturnedToTitle?.Invoke();
        Debug.Log("Return to Title");
    }

    private void HandleQuitClicked()
    {
        Application.Quit();
    }

    private void PlayTransitionCutscene()
    {
        Debug.Log("Play Transition");

    }
}