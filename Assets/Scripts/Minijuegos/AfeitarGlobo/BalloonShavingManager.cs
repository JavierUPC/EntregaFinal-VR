using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BalloonShavingManager : MonoBehaviour
{
    public AnimationCurve targetPressureCurve;
    public float gameDuration = 10f;
    public float acceptableTolerance = 0.1f;
    public SkinnedMeshRenderer foamLayer;
    public GameObject balloon;
    public GameObject popEffect;

    private float elapsedTime = 0f;
    private bool gameActive = false;
    private InputDevice device;

    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        GenerateRandomCurve();
        StartGame(); // Start immediately for testing
    }

    void Update()
    {
        if (!gameActive) return;

        elapsedTime += Time.deltaTime;
        float normalizedTime = Mathf.Clamp01(elapsedTime / gameDuration);

        float targetPressure = targetPressureCurve.Evaluate(normalizedTime);
        float currentPressure = GetTriggerPressure();

        // Visual foam feedback (blend shape weight from 100 to 0)
        float foamBlend = Mathf.Lerp(100f, 0f, normalizedTime);
        foamLayer.SetBlendShapeWeight(0, foamBlend);

        // Haptics
        SendHapticFeedback(currentPressure, targetPressure);

        // Check failure
        if (Mathf.Abs(currentPressure - targetPressure) > acceptableTolerance * 2f)
        {
            EndGame(false);
        }

        if (elapsedTime >= gameDuration)
        {
            EndGame(true);
        }
    }

    private float GetTriggerPressure()
    {
        if (device.TryGetFeatureValue(CommonUsages.trigger, out float value))
        {
            return value;
        }
        return 0f;
    }

    private void SendHapticFeedback(float current, float target)
    {
        float diff = Mathf.Abs(current - target);
        float amplitude = diff < acceptableTolerance ? 0.2f : 0.05f;
        device.SendHapticImpulse(0u, amplitude, 0.05f);
    }

    private void GenerateRandomCurve()
    {
        targetPressureCurve = new AnimationCurve();
        targetPressureCurve.AddKey(0f, Random.Range(0.2f, 1f));
        targetPressureCurve.AddKey(gameDuration * 0.3f, Random.Range(0.1f, 0.5f));
        targetPressureCurve.AddKey(gameDuration * 0.6f, Random.Range(0.3f, 0.9f));
        targetPressureCurve.AddKey(gameDuration, Random.Range(0.5f, 1f));
    }

    public void StartGame()
    {
        elapsedTime = 0f;
        gameActive = true;
    }

    private void EndGame(bool success)
    {
        gameActive = false;
        if (!success)
        {
            Instantiate(popEffect, balloon.transform.position, Quaternion.identity);
            Destroy(balloon);
        }
        else
        {
            Debug.Log("Shaving complete!");
        }
    }
}
