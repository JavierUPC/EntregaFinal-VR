using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject balloon;
    public FoamManager foamManager;
    public Material winMaterial;
    private Material startMaterial;

    private void Start()
    {
        startMaterial = balloon.GetComponent<Renderer>().material;
    }

    public bool isActive = false;

    public void StartMinigame()
    {
        balloon.SetActive(true);
        foamManager.ResetFoam();
        isActive = true;
    }

    public void BalloonPopped()
    {
        Debug.Log("Balloon Popped!");
        EndMinigame();
    }

    public void Win()
    {
        Debug.Log("Balloon Shaved!");
        balloon.GetComponent<Renderer>().material = winMaterial;
        StartCoroutine(WinTimer());
    }

    private IEnumerator WinTimer()
    {
        yield return new WaitForSeconds(3f);
        EndMinigame();
    }

    private void EndMinigame()
    {
        balloon.GetComponent<Renderer>().material = startMaterial;
        isActive = false;
        balloon.SetActive(false);
    }
}
