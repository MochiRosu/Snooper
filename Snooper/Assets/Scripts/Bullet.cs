using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    float despawnTimer = 15f; // Set the despawn time to 15 seconds

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // Decrement the despawn timer
        despawnTimer -= Time.deltaTime;

        // Check if the timer has reached zero
        if (despawnTimer <= 0f)
        {
            // If the timer has reached zero, destroy the bullet GameObject
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}
