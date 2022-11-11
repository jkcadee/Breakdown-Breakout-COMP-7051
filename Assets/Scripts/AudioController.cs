using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController aCtrl;
    public GameObject bgMusic1;
    private AudioSource levelMusic;

    public void Awake()
    {
        if (aCtrl == null)
        {
            levelMusic = bgMusic1.GetComponent<AudioSource>();
            levelMusic.loop = true;
            aCtrl = this;
            PlayMusic();
        }
    }

    public static void PlaySFX(AudioSource sfx) {
        sfx.Play();
    }

    public void StopMusic()
    {
        levelMusic.Stop();
    }
    public void PauseMusic()
    {
        levelMusic.Pause();
    }
    public void PlayMusic()
    {
        levelMusic.Play();
    }
}
