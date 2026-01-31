using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private string gameplaySceneName = "FinalGameplayScene";

    private void OnEnable()
    {
        StartMenuManager.OnStartGameRequested += PlayCutscene;
        director.stopped += OnCutsceneFinished;
    }

    private void OnDisable()
    {
        StartMenuManager.OnStartGameRequested -= PlayCutscene;
        director.stopped -= OnCutsceneFinished;
    }

    private void PlayCutscene()
    {
        Debug.Log("Cutscene Started");
        director.Play();
    }

    private void OnCutsceneFinished(PlayableDirector playableDirector)
    {
        SceneManager.LoadScene(gameplaySceneName);
    }
}