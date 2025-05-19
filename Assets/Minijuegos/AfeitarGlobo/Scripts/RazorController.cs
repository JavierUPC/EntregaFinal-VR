using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RazorController : MonoBehaviour
{
    public XRNode controllerNode = XRNode.RightHand;
    public MinigameManager minigameManager;
    public float minPressure = 0.4f;
    public float maxPressure = 0.6f;

    private InputDevice device;

    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    void OnTriggerStay(Collider other)
    {
        if (!minigameManager.isActive) return;

        if (device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            if (triggerValue > maxPressure)
            {
                minigameManager.BalloonPopped();
            }
            else if (triggerValue >= minPressure)
            {
                FoamPatch foam = other.GetComponent<FoamPatch>();
                if (foam != null)
                {
                    foam.Shave();
                }
            }
        }
    }
}
