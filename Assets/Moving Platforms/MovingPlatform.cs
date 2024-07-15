using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private Transform[] positions;

    [SerializeField] private float period = 5.0f;

    private Rigidbody _rigidbody = null;
    private float timer = 0.0f;
    private int step = 0;

    [SerializeField] private List<Rigidbody> heldObjects = new List<Rigidbody>();

    private void Awake () 
    {
        // Setup the rigidbody
        _rigidbody = platform.GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Increment steptimer
        timer += Time.deltaTime;
        // Calculate the time between the current point and the next point
        float t = EaseInOut(timer, period);
        // Use time to calculate the position between the points
        Vector3 p = Vector3.Lerp(positions[step].position, positions[(step + 1) % positions.Length].position, t);
        // Save the before pos
        Vector3 beforePos = platform.position;
        // Move the rigidbody
        _rigidbody.MovePosition(p);
        // Save the after pos
        Vector3 afterPos = platform.position;

        // Move any objects that are "held"
        foreach(Rigidbody obj in heldObjects)
        {
            Vector3 offset = obj.position - platform.position;

            obj.MovePosition(p + offset);
        }   

        // Check if we've hit the current step, and move to the next one, and reset timer
        if (timer > period) {
            step = (step + 1) % positions.Length;
            timer = 0.0f;
        }
    }

    public float EaseInOut (float time, float duration) {
        return -0.5f * (Mathf.Cos(Mathf.PI * time / duration) - 1.0f);
    }


    public void AddTransform(Rigidbody obj) 
    { 
        if (!heldObjects.Contains(obj)) heldObjects.Add(obj);
    }

    public void RemoveTransform(Rigidbody obj) 
    { 
        if (heldObjects.Contains(obj)) heldObjects.Remove(obj);
    }
}
