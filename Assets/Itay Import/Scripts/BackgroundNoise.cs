using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundNoise : MonoBehaviour
{
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false && audioSource.GetComponent<ComputerScreenUnstable>().isActiveAndEnabled == false)
            audioSource.PlayOneShot(audioSource.clip, 0.3f);
    }
}
