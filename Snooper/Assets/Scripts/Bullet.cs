using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1.0f;
    public float lifespan = 5.0f; // Time in seconds before the bullet disappears.

    private void Start()
    {
        // Schedule the bullet to be destroyed after the specified lifespan.
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            Destroy(other.gameObject); // Destroy the enemy GameObject.

            // Optionally, you can add more logic here based on the tag.
        }
    }
}
