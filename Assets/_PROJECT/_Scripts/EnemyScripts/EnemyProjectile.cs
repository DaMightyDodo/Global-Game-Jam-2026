using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 3f;
    void Start()
    {
        // Destroy the projectile after its lifetime expires
        Destroy(gameObject, lifetime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the projectile on collision with any object
        Destroy(gameObject);
    }
}
