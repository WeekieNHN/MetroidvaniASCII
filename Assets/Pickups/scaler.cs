using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaler : MonoBehaviour
{
    [SerializeField] private float amount = 0.1f;
    [SerializeField] private float speed = 1f;

    private void Awake () 
    {
        startTime = Time.time;
    }

    float startTime = 0f;
    private void Update ()
    {
        // Set the scale of the object
        float scaleAddition = Mathf.Cos(speed * (Time.time - startTime)) * amount;
        transform.localScale = Vector3.one + new Vector3(scaleAddition, scaleAddition, scaleAddition);
    }
}
