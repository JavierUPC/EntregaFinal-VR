using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGameButton : MonoBehaviour
{
    public GestorAros gestorAros;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Bot�n pulsado. �Empezamos/reiniciamos partida!");

        // Reiniciar puntuaci�
        PuntuacioManager.Instance?.ReiniciarPunts();

        // Eliminar aros existents
        foreach (GameObject aro in GameObject.FindGameObjectsWithTag("Ring"))
        {
            Destroy(aro);
        }

        // Reiniciar contador d'aros
        if (gestorAros != null)
        {
            gestorAros.ReiniciarAros();

            // Crear els primers aros
            gestorAros.CrearNouAro();
        }
    }
}
