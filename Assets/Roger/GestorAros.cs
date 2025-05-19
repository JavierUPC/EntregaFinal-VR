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

    // Guardarem la posició i rotació originals per assegurar que no canvien
    private Vector3 posicioInicialAro;
    private Quaternion rotacioInicialAro;

    void Start()
    {
        // Emmagatzemem la posició i rotació originals del spawnPoint
        if (spawnPoint != null)
        {
            posicioInicialAro = spawnPoint.position;
            rotacioInicialAro = spawnPoint.rotation;
        }
        else
        {
            Debug.LogError("SpawnPoint no està assignat al GestorAros!");
        }
    }

    public void CrearNouAro()
    {
        if (arosLanzados < maxAros)
        {
            Instantiate(prefabAro, posicioInicialAro, rotacioInicialAro);
            arosLanzados++;
        }
    }

    // Per reiniciar si vols (opcional)
    public void ReiniciarAros()
    {
        arosLanzados = 0;
    }
}
