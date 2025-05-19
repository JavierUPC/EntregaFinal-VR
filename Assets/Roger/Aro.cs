using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Aro : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool hasBeenGrabbed = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
            grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (hasBeenGrabbed)
        {
            GestorAros gestor = FindObjectOfType<GestorAros>();
            if (gestor != null)
            {
                gestor.CrearNouAro();
            }
        }

        hasBeenGrabbed = true;
    }
}
