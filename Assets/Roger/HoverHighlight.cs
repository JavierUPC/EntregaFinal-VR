using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverHighlight : MonoBehaviour
{
    public Material hoverMaterial;
    private Renderer rend;
    private Material[] originalMaterials;

    private void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            originalMaterials = rend.materials;
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (rend != null && hoverMaterial != null)
        {
            // Crear un nuevo array con un slot extra para el overlay
            Material[] newMats = new Material[originalMaterials.Length + 1];
            originalMaterials.CopyTo(newMats, 0);
            newMats[originalMaterials.Length] = hoverMaterial;
            rend.materials = newMats;
        }
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        if (rend != null)
        {
            rend.materials = originalMaterials;
        }
    }
}
