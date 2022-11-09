using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource death;
    public AudioSource hit;
    public AudioSource pickup;
    public AudioSource shoot;

    public void Awake()
    {   
            levelMusic.loop = true;
            PlayMusic();
    }
/**
    public static void PlaySFX(AudioSource sfx) {
        sfx.Play();
    }
*/
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

    public void PlayDeath() {

        death.Play();

    }

    public void PlayHit()
    {
        hit.Play();
    }

    public void PlayPickup()
    {
        pickup.Play();
    }

    public void PlayShoot()
    {
        shoot.Play();
    }

}
