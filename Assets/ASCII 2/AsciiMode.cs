using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsciiMode : MonoBehaviour
{
    public static AsciiMode instance;
    private void Awake () => instance = this;

    public List<GameObject> AsciiObjects = new List<GameObject>();

    private void Start () => SetMode(false);

    public static void SetMode(bool value)
    {
        foreach(GameObject obj in instance.AsciiObjects) 
        {
            obj.SetActive(value);
        }
    }
}
