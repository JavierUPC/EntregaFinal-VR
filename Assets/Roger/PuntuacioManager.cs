using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntuacioManager : MonoBehaviour
{
    public static PuntuacioManager Instance;

    public int puntuacioActual = 0;
    public int highScore = 0;

    public Text currentScoreText;
    public Text highScoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void SumarPunts(int punts)
    {
        puntuacioActual += punts;
        Debug.Log("Punts: " + puntuacioActual);
        if (puntuacioActual > highScore)
        {
            highScore = puntuacioActual;
        }
        UpdateScoreUI();
    }

    public void ReiniciarPunts()
    {
        puntuacioActual = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = "SCORE: " + puntuacioActual;

        if (highScoreText != null)
            highScoreText.text = "HIGH SCORE: " + highScore;
    }
}

