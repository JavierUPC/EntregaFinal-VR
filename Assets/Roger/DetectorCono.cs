using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeDetector : MonoBehaviour
{
    public ParticleSystem confetti;
    public int umbralMinimColiders = 6; // Pots modificar-lo des de l'inspector

    private HashSet<Collider> colidersDins = new HashSet<Collider>();
    private Coroutine checkCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            colidersDins.Add(other);

            if (checkCoroutine == null)
                checkCoroutine = StartCoroutine(CheckIfStayed());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            colidersDins.Remove(other);
        }
    }

    private IEnumerator CheckIfStayed()
    {
        yield return new WaitForSeconds(1f);

        // Filtra col·lidors nulls (per si s’han destruït a mig procés)
        colidersDins.RemoveWhere(c => c == null);

        if (colidersDins.Count >= umbralMinimColiders)
        {
            Debug.Log($"Aro encertat amb {colidersDins.Count} col·lidors dins.");

            if (confetti != null) confetti.Play();
            PuntuacioManager.Instance?.SumarPunts(10);

            // Destrueix l'objecte pare (l'aro sencer)
            Collider primer = null;
            foreach (var c in colidersDins)
            {
                if (c != null)
                {
                    primer = c;
                    break;
                }
            }

            if (primer != null)
                Destroy(primer.transform.root.gameObject, 1f); // Destrueix l’objecte complet

        }
        else
        {
            Debug.Log($"Tiro rebutjat: només {colidersDins.Count} col·lidors dins.");
        }

        colidersDins.Clear();
        checkCoroutine = null;
    }
}
