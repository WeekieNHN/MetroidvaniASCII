using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public Vector3 startPoint;  // Starting position
    public Vector3 endPoint;    // Ending position
    public float duration = 3.0f;  // Duration of the lerp

    private float elapsedTime = 0.0f;
    private bool isLerping = false;
    
    void Update()
    {
        if (isLerping)
        {
            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the lerp factor
            float t = elapsedTime / duration;

            // Apply S-curve using SmoothStep function
            t = Mathf.SmoothStep(0, 1, t);

            // Lerp from start to end point
            transform.localPosition = Vector3.Lerp(startPoint, endPoint, t);

            // Stop lerping if the duration is reached
            if (elapsedTime >= duration)
            {
                isLerping = false;
                elapsedTime = 0.0f; // Reset elapsed time if you want to lerp again
            }
        }
    }

    // Method to start the lerp
    public void StartLerping()
    {
        elapsedTime = 0.0f;
        isLerping = true;
    }
}
