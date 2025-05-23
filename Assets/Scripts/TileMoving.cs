using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TileMoving : MonoBehaviour
{
    public Transform leftRayOrigin;
    public Transform rightRayOrigin;

    public InputActionReference leftTriggerAction;
    public InputActionReference rightTriggerAction;

    public Transform xrOrigin;
    public LayerMask tileLayer;
    public float teleportSpeed = 5f;

    private bool isTeleporting = false;

    void Update()
    {
        if (!isTeleporting)
        {
            TryTeleport(leftRayOrigin, leftTriggerAction);
            TryTeleport(rightRayOrigin, rightTriggerAction);
        }
    }

    void TryTeleport(Transform rayOrigin, InputActionReference triggerAction)
    {
        if (triggerAction.action.ReadValue<float>() > 0.1f)
        {
            if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out RaycastHit hit, 100f, tileLayer))
            {
                if (hit.collider.CompareTag("Tile"))
                {
                    StartCoroutine(TeleportTo(hit.point));
                }
            }
        }
    }

    IEnumerator TeleportTo(Vector3 targetPos)
    {
        isTeleporting = true;

        Vector3 start = xrOrigin.position;
        Vector3 end = new Vector3(targetPos.x, start.y, targetPos.z); 

        float distance = Vector3.Distance(start, end);
        float duration = distance / teleportSpeed;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            xrOrigin.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        xrOrigin.position = end;
        isTeleporting = false;
    }
}
