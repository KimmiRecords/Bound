using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource pickup;
    public AudioSource bgm;
    public AudioSource screamer1;
    public AudioSource mainMenuMusic;
    public AudioSource pPlateOn;
    public AudioSource pPlateOff;

    private float volumenDeseadoScreamer;

    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);

        volumenDeseadoScreamer = screamer1.volume;
    }

    void Update()
    {
        
    }

    //ARRANCAN LOS METODOS

    //PICKUPS SFX
    public void PlayPickup(float p)
    {
        pickup.pitch = p;
        pickup.Play();
    }

    //PRESSURE PLATE SFX
    public void PlayPPlateOn()
    {
        pPlateOn.Play();
    }
    public void PlayPPlateOff()
    {
        pPlateOff.Play();
    }


    //BACKGROUNDMUSIC
    public void PlayBGM()
    {
        bgm.Play();
    }
    public void StopBGM()
    {
        bgm.Stop();
    }
    public void FadeInBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        bgm.volume = Mathf.Lerp(0, 1, timer);
    }
    public void FadeOutBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        bgm.volume = Mathf.Lerp(1, 0, timer);
    }


    //SCREAMER SFX
    public void PlayScreamer1()
    {
        screamer1.volume = volumenDeseadoScreamer;   
        screamer1.Play();
    }
    public void FadeOutScreamer1(float fadetime)
    {
        float timer = Time.time / fadetime;
        screamer1.volume = Mathf.Lerp(1, 0, timer);
    }
    public void StopScreamer1()
    {
        screamer1.Stop();
    }


    //MAIN MENU MUSIC
    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Play();
    }
    public void StopMainMenuMusic()
    {
        mainMenuMusic.Stop();
    }

    
}
