using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorAros : MonoBehaviour
{
    [Header("Configuració")]
    public GameObject prefabAro;
    public Transform spawnPoint;
    public int maxAros = 3;

    private int arosLanzados = 0;

    public void CrearNouAro()
    {
        if (arosLanzados < maxAros)
        {
            Instantiate(prefabAro, spawnPoint.position, spawnPoint.rotation);
            arosLanzados++;
        }
    }

    // Per reiniciar si vols (opcional)
    public void ReiniciarAros()
    {
        arosLanzados = 0;
    }
}
