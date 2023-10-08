using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float launchForce;
    public Transform shotPoint;

    private Vector2 dragStartPos;
    private bool isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Store the initial position of the drag
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            // Calculate the drag distance and direction
            Vector2 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dragDirection = (dragStartPos - dragEndPos).normalized; // Inverted direction
            float dragDistance = Vector2.Distance(dragStartPos, dragEndPos);

            // Shoot the bullet
            Shoot(dragDirection, dragDistance);

            isDragging = false;
        }
    }

    void Shoot(Vector2 direction, float forceMultiplier)
    {
        GameObject newBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * launchForce * forceMultiplier;
    }
}
