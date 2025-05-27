using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroSoundManager : MonoBehaviour
{
    public AudioSource[] audioSources; // 3 AudioSources, un per cada grup de col·liders

    // Assigna els col·liders als grups i conecta aquest script als col·liders
    // Aquí suposem que cada col·lider té un script ColliderSound que avisarà aquest manager

    public void PlaySoundForCollider(int groupIndex)
    {
        if (groupIndex >= 0 && groupIndex < audioSources.Length)
        {
            audioSources[groupIndex].Play();
        }
    }
}
