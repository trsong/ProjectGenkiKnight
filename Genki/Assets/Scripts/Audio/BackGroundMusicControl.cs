using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip normalBGM;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        normalBGM = audioSource.clip;
        audioSource.Play();
    }

    public void playBGM(AudioClip clip)
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
            normalBGM = audioSource.clip;
        }
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void resetBGM()
    {
        audioSource.Stop();
        audioSource.clip = normalBGM;
        audioSource.Play();
    }

}
