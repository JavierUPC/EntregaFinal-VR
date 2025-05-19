using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamPatch : MonoBehaviour
{
    public bool isShaved = false;

    public void Shave()
    {
        if (!isShaved)
        {
            isShaved = true;
            gameObject.SetActive(false);
            FindObjectOfType<FoamManager>().FoamPieceShaved();
        }
    }

    public void ResetPatch()
    {
        isShaved = false;
        gameObject.SetActive(true);
    }
}
