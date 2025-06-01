using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject balloon;
    public FoamManager foamManager;
    public Material winMaterial;
    private Material startMaterial;

    public Text currentScoreText;
    public Text highScoreText;

    private float startTime;
    private float currentScore;
    private float highScore = Mathf.Infinity;

    public bool isActive = false;
    private bool balloonPopped = false;

    private void Start()
    {
        startMaterial = balloon.GetComponent<Renderer>().material;
        UpdateUI();
    }

    void Update()
    {
        if (isActive && !balloonPopped)
        {
            float liveScore = Time.time - startTime;
            currentScoreText.text = "SCORE: " + liveScore.ToString("F2") + "s";
        }
    }

    public void StartMinigame()
    {
        balloon.SetActive(true);
        foamManager.ResetFoam();
        isActive = true;
        balloonPopped = false;
        startTime = Time.time;
        currentScore = 0;
        UpdateUI();
    }

    public void BalloonPopped()
    {
        Debug.Log("Balloon Popped!");
        //Sonido petar globo
        //Parar de contar tiempo y reiniciarlo: no se guarda la score porque ha perdido el juego.
        balloonPopped = true;
        EndMinigame(false);
    }

    public void Win()
    {
        if (!isActive || balloonPopped) return;

        Debug.Log("Balloon Shaved!");
        currentScore = Time.time - startTime;
        if (currentScore < highScore)
        {
            highScore = currentScore;
        }
        UpdateUI();
        //Sonido Win
        balloon.GetComponent<Renderer>().material = winMaterial;
        StartCoroutine(WinTimer());
    }

    private IEnumerator WinTimer()
    {
        yield return new WaitForSeconds(3f);
        EndMinigame(true);
    }

    private void EndMinigame(bool won)
    {
        isActive = false;
        balloon.SetActive(false);
        balloon.GetComponent<Renderer>().material = startMaterial;

        if (!won)
        {
            currentScore = 0;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        currentScoreText.text = "SCORE: " + (currentScore > 0 ? currentScore.ToString("F2") + "s" : "--");
        highScoreText.text = "HIGH SCORE: " + (highScore < Mathf.Infinity ? highScore.ToString("F2") + "s" : "--");
    }
}
