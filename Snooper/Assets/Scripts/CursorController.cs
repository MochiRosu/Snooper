using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    void Update()
    {
        // Get the current mouse position or touch position
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = 10; // Set the Z position to ensure it's visible on top of other objects

        // Convert screen position to world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

        // Set the cursor's position
        transform.position = worldPosition;
    }
}
