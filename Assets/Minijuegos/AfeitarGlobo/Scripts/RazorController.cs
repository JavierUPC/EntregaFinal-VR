using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RazorController : MonoBehaviour
{
    public XRNode controllerNode = XRNode.RightHand;
    public MinigameManager minigameManager;
    public float minPressure = 0.4f;
    public float maxPressure = 0.7f;

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
            if (triggerValue > maxPressure - 0.07f)
            {
                // Vibración háptica de potencia 5/10
                SendHaptics(0.5f, 0.1f);
            }

            if (triggerValue > maxPressure)
            {
                // Vibración háptica de potencia 10/10
                SendHaptics(1.0f, 0.2f);
                minigameManager.BalloonPopped();
            }
            else if (triggerValue >= minPressure)
            {
                // Vibración háptica de potencia 1/10
                SendHaptics(0.02f, 0.05f);

                FoamPatch foam = other.GetComponent<FoamPatch>();
                if (foam != null)
                {
                    foam.Shave();
                }
            }
        }
    }

    private void SendHaptics(float amplitude, float duration)
    {
        if (device.isValid && device.TryGetHapticCapabilities(out HapticCapabilities capabilities) && capabilities.supportsImpulse)
        {
            device.SendHapticImpulse(0, amplitude, duration);
        }
    }
}
