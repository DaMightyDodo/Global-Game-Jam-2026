using System;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    public static event Action OnControlMenuOpened;
    public static event Action OnReturnedToTitle;
    public static event Action OnStartGameRequested;

    [SerializeField] private StartMenuButtons _startUI;
    [SerializeField] private GameObject _backButton;

    private void Awake()
    {
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
    }

    private void HandleBackClicked()
    {
        _startUI.gameObject.SetActive(true);
        _backButton.SetActive(false);
        OnReturnedToTitle?.Invoke();
    }

    private void HandleQuitClicked()
    {
        Application.Quit();
    }

    private void PlayTransitionCutscene()
    {
        Debug.Log("Request Transition Cutscene");
        OnStartGameRequested?.Invoke();
    }
}