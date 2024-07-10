using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigButton : MonoBehaviour
{
    [Header("Event")]
    public UnityEvent OnPress = new UnityEvent();

    [Header("Handle")]
    public Transform handle;

    // Start is called before the first frame update
    void Start() => OnPress.AddListener(HandlePress);

    private void HandlePress ()
    {
       Destroy(handle.gameObject);
    }
}
