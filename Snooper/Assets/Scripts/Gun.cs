using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 Direction;

    private bool isAiming; // Indicates whether the player is currently aiming

    private void Start()
    {
        // Initialize the points array and instantiate the points
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
            // Offset the position of each point along the shotPoint's forward direction
            points[i].transform.Translate(Vector3.forward * spaceBetweenPoints * i);
        }
    }

    private void Update()
    {
        // Detect a tap and hold
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isAiming = true;
                    break;

                case TouchPhase.Ended:
                    isAiming = false;
                    Shoot(); // Fire the bullet when the finger is lifted
                    break;
            }

            if (isAiming)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Direction = touchPosition - (Vector2)transform.position;
                transform.right = Direction;
            }
        }

        // Update trajectory prediction points while aiming
        if (isAiming)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
        }
    }

    void Shoot()
    {
        // Create a bullet and set its position and force
        GameObject newBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (Direction.normalized * launchForce * t);
        return position;
    }
}
