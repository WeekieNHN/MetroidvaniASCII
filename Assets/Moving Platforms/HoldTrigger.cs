using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTrigger : MonoBehaviour
{
    [SerializeField] private MovingPlatform movingPlatform;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<Rigidbody>()) movingPlatform.AddTransform(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.GetComponent<Rigidbody>()) movingPlatform.RemoveTransform(other.GetComponent<Rigidbody>());
    }
}
