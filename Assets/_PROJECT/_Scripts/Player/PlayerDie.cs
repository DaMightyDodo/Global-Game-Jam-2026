using System;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public static event Action OnPlayerDie;

    [Header("Debug")]
    [SerializeField] private GameObject _deadPlayerPrefab;
    [SerializeField] private PlayerController _playerController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("Germ"))
        {
            HandleDie();
        }
    }

    private void HandleDie()
    {
        Die();
    }

    private void Die()
    {
        if (_deadPlayerPrefab != null)
        {
            Instantiate(
                _deadPlayerPrefab,
                transform.position,
                transform.rotation
            );
        }

        OnPlayerDie?.Invoke();

        Destroy(gameObject);
    }
}