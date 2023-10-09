using UnityEditor.Experimental.GraphView;
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
        Vector2 gunPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = mousePosition - gunPosition;
        transform.right = Direction;

        if(Input .GetMouseButtonDown(0))
        {
            Shoot();
        }
        for (int i = 0; i <numberOfPoints;i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void Shoot()
    {
        // Create a bullet and set its position and force
        GameObject newBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce ;
    }
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (Direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
