using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    [SerializeField] private GameObject popObject;

    private void OnTriggerEnter(Collider other) 
    {
        // Return if no player script
        if (!other.gameObject.GetComponent<PlayerController>()) return;

        // Set the max jump count
        other.gameObject.GetComponent<PlayerController>().maxJumpCount = 2;

        other.gameObject.GetComponent<PlayerController>().SetTrail(true);

        // Spawn a pop at our position
        if (popObject) 
        {
            // Spawn a pop object
            GameObject pop = Instantiate(popObject, transform.position, Quaternion.identity);
            // Destroy pop object when done
            Destroy(pop, 1.5f);
        }

        // Destroy ourselves
        Destroy(gameObject, 0.05f);
    }
}
