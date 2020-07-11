using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerArea : MonoBehaviour
{
    public AudioClip clip;
    private BackGroundMusicControl control;
    void Start()
    {
        control = FindObjectOfType<BackGroundMusicControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.playBGM(clip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.resetBGM();
        }
    }
}
