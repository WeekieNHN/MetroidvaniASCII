using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;

    private void OnTriggerStay(Collider other) 
    {
        // Move Camera if the player entered
        if (!other.GetComponent<PlayerController>()) return;

        // Change the camera angle
        RoomCameraManager.ChangeCamera(cameraPosition.position);
    }
}
