using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialSwapper : MonoBehaviour
{
    public Material onMaterial;
    public Material offMaterial;

    Renderer meshRenderer = null;

    private void Awake() => meshRenderer = GetComponent<Renderer>();
    private void Start() => AsciiMode.ModeChangedEvent.AddListener(UpdateMaterial);

    private void UpdateMaterial (bool value)
    {
        if (meshRenderer == null) return;

        Material[] newMaterials = new Material[meshRenderer.materials.Length];

        for (int i = 0; i < newMaterials.Length; i++)
        {
            newMaterials[i] = value ? onMaterial : offMaterial;
        }

        meshRenderer.materials = newMaterials;
    }
}
