using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGameButton : MonoBehaviour
{
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Bot�n pulsado. �Empezamos partida!");
        // Aqu� inicia tu l�gica para empezar la partida
        // Por ejemplo: SceneManager.LoadScene("NombreEscena");
    }
}