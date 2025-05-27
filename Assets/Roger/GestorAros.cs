using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorAros : MonoBehaviour
{
    [Header("Configuració")]
    public GameObject prefabAro;
    public Transform spawnPoint;
    public GameObject aroOriginal;  // <- EmptyAnella real de l'escena
    public int maxAros = 3;

    private int arosLanzados = 0;
    private Vector3 posicioInicialAro;
    private Quaternion rotacioInicialAro;
    private List<GameObject> arosInstanciats = new List<GameObject>();

    void Start()
    {
        if (spawnPoint != null)
        {
            posicioInicialAro = spawnPoint.position;
            rotacioInicialAro = spawnPoint.rotation;
        }
        else
        {
            Debug.LogError("SpawnPoint no assignat!");
        }

        if (aroOriginal == null)
        {
            Debug.LogError("AroOriginal no assignat!");
        }
    }

    public void CrearNouAro()
    {
        if (arosLanzados < maxAros)
        {
            GameObject nouAro = Instantiate(prefabAro, posicioInicialAro, rotacioInicialAro);

            //Assegurem-nos que només afegim les còpies, no l’original
            if (nouAro != aroOriginal)
            {
                arosInstanciats.Add(nouAro);
                arosLanzados++;
            }
        }
    }

    public void ReiniciarAros()
    {
        //1. Eliminar NOMÉS les còpies (aros instanciats)
        foreach (GameObject aro in arosInstanciats)
        {
            if (aro != null)
                Destroy(aro);
        }

        arosInstanciats.Clear();
        arosLanzados = 0;

        //2. Recol·locar l’aro original
        if (aroOriginal != null)
        {
            aroOriginal.transform.position = posicioInicialAro;
            aroOriginal.transform.rotation = rotacioInicialAro;

            //3. Reset de forces
            Rigidbody rb = aroOriginal.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            //4. Tornar-lo actiu (per si l'havíem desactivat)
            aroOriginal.SetActive(true);
        }
    }
}
