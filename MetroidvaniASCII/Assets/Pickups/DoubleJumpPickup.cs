using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        // Return if no player script
        if (!other.gameObject.GetComponent<PlayerController>()) return;

        // Set the max jump count
        other.gameObject.GetComponent<PlayerController>().maxJumpCount = 2;

        // Destroy ourselves
        Destroy(gameObject, 0.05f);
    }
}
