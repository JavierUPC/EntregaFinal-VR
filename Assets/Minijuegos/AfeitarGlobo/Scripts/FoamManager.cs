using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamManager : MonoBehaviour
{
    public FoamPatch[] foamPatches;
    private int totalFoam;
    private int shavedFoam;

    void Start()
    {
        foamPatches = GetComponentsInChildren<FoamPatch>();
        totalFoam = foamPatches.Length;
    }

    public void FoamPieceShaved()
    {
        shavedFoam++;
        if (shavedFoam >= totalFoam)
        {
            FindObjectOfType<MinigameManager>().Win();
        }
    }

    public void ResetFoam()
    {
        foreach (var patch in foamPatches)
        {
            patch.ResetPatch();
        }
        shavedFoam = 0;
    }
}
