using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnModeChangeAction : MonoBehaviour
{
    public UnityEvent ToNormalEvent = new UnityEvent();
    public UnityEvent ToAsciiEvent = new UnityEvent();

    private void Start() 
    {
        // Subscribe to event
        AsciiMode.ModeChangedEvent.AddListener(RunEvents);

        // Apply event to sync to mode
        RunEvents(AsciiMode.IsActive);
    }

    private void RunEvents (bool value)
    {
        if (value) ToAsciiEvent.Invoke();
        else ToNormalEvent.Invoke();
    }

    public void Message (string msg) => Debug.Log(msg);
    
    // Function to show or hide an object
    public void SetObjectVisible(bool isVisible)
    {
        // Get all the renderers and colliders on the object
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

        // Enable or disable all renderers
        foreach (Renderer renderer in renderers)
            renderer.enabled = isVisible;

        // Enable or disable all colliders
        foreach (Collider collider in colliders)
            collider.enabled = isVisible;
    }
}
