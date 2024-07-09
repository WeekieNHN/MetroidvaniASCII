using UnityEngine;

public class RoomCameraManager : MonoBehaviour
{

    public static RoomCameraManager instance { get; private set; }

    private void Awake () => instance = this;

    [SerializeField] private Transform Camera;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public static void ChangeCamera(Vector3 position)
    {
        // Only run the change once
        if (instance.Camera.position == position) return;

        // Set camera position
        instance.Camera.position = position;
    }
}
