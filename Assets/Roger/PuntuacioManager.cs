using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntuacioManager : MonoBehaviour
{
    public static PuntuacioManager Instance;

    public int puntuacioActual = 0;

    // falta tamb�en la high score

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SumarPunts(int punts)
    {
        puntuacioActual += punts;
        Debug.Log("Punts: " + puntuacioActual);
        // Aqu� pots notificar la UI si vols actualitzar-la
        //Ense�ar los puntos en score y si ha sido la m�s alta hasta ahora ponerla en high score.
    }

    public void ReiniciarPunts()
    {
        puntuacioActual = 0;
    }
}

