using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobber : MonoBehaviour
{
    [SerializeField] private float distance = 0.1f;
    [SerializeField] private float speed = 1f;

    private void Awake () 
    {
        startPos = transform.position;
        startTime = Time.time;
    }

    Vector3 startPos;
    float startTime = 0f;
    private void Update ()
    {
        // Set the position of the orb
        transform.position = startPos + new Vector3(0f, Mathf.Cos(speed * (Time.time - startTime)) * distance, 0f);
    }
}
