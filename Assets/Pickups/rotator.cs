using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;

    private void Update ()
    {
        // Set the rotation of the object
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + (velocity * Time.deltaTime));
    }
}
