using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarAltura : MonoBehaviour
{
    [SerializeField] private Transform xrCamera;
    [SerializeField] private MinigameManager minigameManager;

    private bool wasActive = false;

    void Start()
    {
        if (xrCamera == null && Camera.main != null)
        {
            xrCamera = Camera.main.transform;
        }

        if (minigameManager == null)
        {
            minigameManager = FindObjectOfType<MinigameManager>();
        }
    }

    void Update()
    {
        if (minigameManager != null)
        {
            if (!wasActive && minigameManager.isActive)
            {
                AjustarAltura();
                wasActive = true;
            }
            else if (!minigameManager.isActive)
            {
                wasActive = false;
            }
        }
    }

    private void AjustarAltura()
    {
        if (xrCamera != null)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y = xrCamera.position.y;
            transform.position = currentPosition;
        }
    }
}
