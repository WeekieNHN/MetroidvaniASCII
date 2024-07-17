using UnityEngine;

public class RotateToPointAtTarget : MonoBehaviour
{
    // Reference to the target transform
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the current position to the target
            Vector3 direction = target.position - transform.position;
            
            // Normalize the direction to get a unit vector
            direction.Normalize();
            
            // Calculate the angle in degrees that we need to rotate around the z-axis
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            // Apply the rotation around the z-axis
            transform.rotation = Quaternion.Euler(0, 0, angle + 180);
        }
    }
}
