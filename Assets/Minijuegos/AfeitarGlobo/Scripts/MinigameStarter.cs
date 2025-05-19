using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameStarter : MonoBehaviour
{
    public MinigameManager minigameManager;

    public void OnSelectEntered()
    {
        if (!minigameManager.isActive)
        {
            minigameManager.StartMinigame();
        }
    }
}
