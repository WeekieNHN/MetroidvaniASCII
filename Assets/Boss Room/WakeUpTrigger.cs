using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WakeUpTrigger : MonoBehaviour
{
    public UnityEvent EnterEvent = new UnityEvent();

    private void OnTriggerEnter(Collider other) 
    {
        if (!other.GetComponent<PlayerController>()) return;

        EnterEvent.Invoke();

        Destroy(gameObject);
    }
}
