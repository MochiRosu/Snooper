using UnityEngine;

public class TrajectoryAim : MonoBehaviour
{
    public LineRenderer lineRenderer; // Reference to the LineRenderer component

    void Start()
    {
        // Get the LineRenderer component attached to this GameObject
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Method to show the trajectory arc
    public void ShowTrajectory(Vector3 startPosition, Vector3 initialVelocity, float timeStep, int numberOfPoints)
    {
        // Set the number of points to display
        lineRenderer.positionCount = numberOfPoints;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float t = i * timeStep;
            Vector3 position = startPosition + initialVelocity * t + 0.5f * Physics.gravity * t * t;
            lineRenderer.SetPosition(i, position);
        }
    }

    // Method to hide the trajectory arc
    public void HideTrajectory()
    {
        // Set the number of points to zero to hide the line
        lineRenderer.positionCount = 0;
    }
}
