using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private StartMenuButtons buttons;

    private void OnEnable()
    {
        buttons.OnClickStart += HandleStartClicked;
        buttons.OnClickControl += HandleControlClicked;
        buttons.OnClickQuit += HandleQuitClicked;
    }

    private void OnDisable()
    {
        buttons.OnClickStart -= HandleStartClicked;
        buttons.OnClickControl -= HandleControlClicked;
        buttons.OnClickQuit -= HandleQuitClicked;
    }

    private void HandleStartClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void HandleControlClicked()
    {
        Debug.Log("Open Controls Menu");
        // Enable controls panel here
    }

    private void HandleQuitClicked()
    {
        Application.Quit();
    }
}