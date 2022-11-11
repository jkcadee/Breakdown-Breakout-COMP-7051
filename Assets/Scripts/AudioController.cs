using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    /** 
     * Sources for code.
     * 
     * Maintaining data persistance between scenes was done using this resource:
        https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#

        The use of multiple audio sources in code was done using this resource:
        https://answers.unity.com/questions/1320031/having-multiple-audio-sources-in-a-single-object.html
    */

    public static AudioController Instance;
    public static AudioSource levelMusic;
    public static AudioSource death;
    public static AudioSource hit;
    public static AudioSource shoot;
    public static AudioSource pickup;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        levelMusic = gameObject.GetComponents<AudioSource>()[0];
        death = gameObject.GetComponents<AudioSource>()[1];
        hit = gameObject.GetComponents<AudioSource>()[2];
        pickup = gameObject.GetComponents<AudioSource>()[3];
        shoot = gameObject.GetComponents<AudioSource>()[4];
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {

        levelMusic.loop = true;
        PlayMusic();

    }

    //public static void PlaySFX(AudioSource sfx) {
    //    sfx.Play();
    //}

    public static void StopMusic()
    {
        levelMusic.Stop();
    }

    public static void PauseMusic()
    {
        levelMusic.Pause();
    }

    public static void PlayMusic()
    {
        levelMusic.Play();
    }

    public static void PlayDeath()
    {
        death.Play();
    }

    public static void PlayHit()
    {
        hit.Play();
    }

    public static void PlayPickup()
    {
        pickup.Play();
    }    

    public static void PlayShoot()
    {
        shoot.Play();
    }

}
