using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothSpeed = 0.125f; 

    void LateUpdate()
    {
        if (target == null)
            return;

        // 1. Calculate and apply the position (same as before)
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // 2. FIX: Reset the camera's rotation to always be level!
        // This ensures the camera never inherits the Pac-Man's rotation.
        transform.rotation = Quaternion.identity; 
    }
}