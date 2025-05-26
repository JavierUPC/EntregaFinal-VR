using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacioManager : MonoBehaviour
{
    public static PuntuacioManager Instance;

    public int puntuacioActual = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SumarPunts(int punts)
    {
        puntuacioActual += punts;
        Debug.Log("Punts: " + puntuacioActual);
        // Aquí pots notificar la UI si vols actualitzar-la
    }

    public void ReiniciarPunts()
    {
        puntuacioActual = 0;
    }
}

