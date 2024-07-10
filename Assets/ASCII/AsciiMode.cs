using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsciiMode : MonoBehaviour
{
    public static AsciiMode instance;
    private void Awake () 
    {
        // save Instance reference
        instance = this;

        // Set the mode
        SetMode(false);
    }

    public static bool IsActive = false;
    public static UnityEvent<bool> ModeChangedEvent = new UnityEvent<bool>();

    // Objects required to render the ascii mode.
    public List<GameObject> AsciiObjects = new List<GameObject>();

    public static void SetMode(bool value)
    {
        // Enable/disable the ascii-related objects
        foreach(GameObject obj in instance.AsciiObjects) obj.SetActive(value);

        // Run event to change the world stuff
        if (IsActive != value) ModeChangedEvent.Invoke(value);

        // Save active value
        IsActive = value;
    }
}
