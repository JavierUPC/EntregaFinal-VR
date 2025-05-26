using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeDetector : MonoBehaviour
{
    public ParticleSystem confetti;  // <-- assigna'l des de l'inspector

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

        if (ring != null && ring.bounds.Intersects(GetComponent<Collider>().bounds))
        {
            Debug.Log($"Aro encertat a: {transform.parent.name}");

            if (confetti != null) confetti.Play();

            // Suma de punts
            PuntuacioManager.Instance?.SumarPunts(10);

            // Opcional: destruir l'aro encertat
            Destroy(ring.gameObject, 1f); // o directament: Destroy(ring.gameObject);
        }

        checkCoroutine = null;
    }

}
