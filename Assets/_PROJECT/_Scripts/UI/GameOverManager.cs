using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void Awake()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerDie.OnPlayerDie += HandlePlayerDie;
    }

    private void OnDisable()
    {
        PlayerDie.OnPlayerDie -= HandlePlayerDie;
    }

    private void HandlePlayerDie()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }
}