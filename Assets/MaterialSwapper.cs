using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialSwapper : MonoBehaviour
{
    public Material onMaterial;
    public Material offMaterial;

    Renderer renderer = null;

    private void Awake() => GetComponent<Renderer>();

    private void Start() => AsciiMode.ModeChangedEvent.AddListener(UpdateMaterial);

    private void UpdateMaterial (bool value)
    {
        Debug.Log("changing material to " + value);

        if (renderer == null) return;

        renderer.materials[0] = (value) ? onMaterial : offMaterial;
    }
}
