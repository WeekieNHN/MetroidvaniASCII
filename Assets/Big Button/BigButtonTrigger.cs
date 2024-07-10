using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButtonTrigger : MonoBehaviour
{
    public BigButton bigButton;

    private void OnTriggerEnter(Collider other) 
    {
        // Return if no player script
        if (!other.gameObject.GetComponent<PlayerController>()) return;

        // Invoke OnPress Event
        bigButton.OnPress.Invoke();

        // Destroy ourselves to prevent being pressed again
        Destroy(gameObject);
    }
}
