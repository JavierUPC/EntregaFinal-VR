using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeDetector : MonoBehaviour
{
    private Coroutine checkCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            checkCoroutine = StartCoroutine(CheckIfStayed(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ring") && checkCoroutine != null)
        {
            StopCoroutine(checkCoroutine);
            checkCoroutine = null;
        }
    }

    private IEnumerator CheckIfStayed(Collider ring)
    {
        yield return new WaitForSeconds(1f);

        // Verifica si el aro sigue dentro tras 1 segundo
        if (ring != null && ring.bounds.Intersects(GetComponent<Collider>().bounds))
        {
            Debug.Log($"Aro encertat a: {transform.parent.name}");

            // Aquí puedes activar puntuación, efectos, etc.
            // Ejemplo:
            // transform.parent.GetComponent<AudioSource>()?.Play();
        }

        checkCoroutine = null;
    }
}
