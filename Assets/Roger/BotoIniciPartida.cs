using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGameButton : MonoBehaviour
{
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Botón pulsado. ¡Empezamos partida!");
        // Aquí inicia tu lógica para empezar la partida
        // Por ejemplo: SceneManager.LoadScene("NombreEscena");
    }
}