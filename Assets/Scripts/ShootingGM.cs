using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingGM : MonoBehaviour
{
    public Text highScoreText;
    public Text currentScoreText;
    public Shoot blaster;
    public int maxBullets = 3;

    private int currentScore = 0;
    private int highScore = 0;
    private int shotsFired = 0;
    private Cans[] allCans;

    void Start()
    {
        allCans = FindObjectsOfType<Cans>();
        UpdateUI();
    }

    public void Shoot()
    {
        Debug.Log("ha disparado!");
        if (shotsFired >= maxBullets)
        {
            return;
        }

        blaster.shoot();
        shotsFired++;
        Debug.Log(shotsFired);

        if (shotsFired == maxBullets)
        {
            StartCoroutine(EndGame());
        }
    }

    public void AddPoint()
    {
        currentScore++;
        UpdateUI();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);

        if (currentScore > highScore)
            highScore = currentScore;

        UpdateUI();
        yield return new WaitForSeconds(2f);

        ResetGame();
    }

    void ResetGame()
    {
        shotsFired = 0;
        currentScore = 0;

        foreach (Cans can in allCans)
        {
            can.ResetCan();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        highScoreText.text = "HIGH SCORE: " + highScore;
        currentScoreText.text = "CURRENT SCORE: " + currentScore;
    }
}
