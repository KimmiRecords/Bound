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
    public AudioSource linternaOn;
    public AudioSource linternaOff;
    public AudioSource pasos1;
    public AudioSource pasos2;
    public AudioSource jumpUp;
    public AudioSource jumpDown;
    public AudioSource doorOpen;
    public AudioSource doorClose;
    public AudioSource hollowRoar;
    public AudioSource accessDenied;


    private float volumenDeseadoScreamer;
    private bool jumpDownIsReady;

    void Start()
    {
        if (instance) //esto es para que audiomanager sea unico. puse uno en cada escena, pero a traves de las escenas se mantiene vivo uno solo.
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //ARRANCAN LOS METODOS



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

    //MAIN MENU MUSIC
    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Play();
    }
    public void StopMainMenuMusic()
    {
        mainMenuMusic.Stop();
    }


    //SFX

    //HOLLOW ROAR
    public void PlayHollowRoar(Vector3 pos, float delayTime)
    {
        if (!hollowRoar.isPlaying)
        {
            hollowRoar.gameObject.transform.position = pos; //muevo al audiosource
            hollowRoar.PlayDelayed(delayTime);
        }
    }


    //PICKUPS SFX
    public void PlayPickup(float p)
    {
        pickup.pitch = p;
        pickup.Play();
    }

    public void PlayAccessDenied()
    {
        accessDenied.Play();
    }

    //PRESSURE PLATE SFX
    public void PlayPPlateOn(Vector3 pos)
    {
        pPlateOn.gameObject.transform.position = pos; //muevo al audiosource
        pPlateOn.Play();
    }
    public void PlayPPlateOff(Vector3 pos)
    {
        pPlateOff.gameObject.transform.position = pos; 
        pPlateOff.Play();
    }

    //PUERTAS
    public void PlayDoorOpen(Vector3 pos)
    {
        float randomPitch = Random.Range(0.95f, 1.05f);
        doorOpen.pitch = randomPitch;
        doorOpen.gameObject.transform.position = pos;
        doorOpen.Play();
    }
    public void PlayDoorClose(Vector3 pos)
    {
        float randomPitch = Random.Range(0.95f, 1.05f);
        doorClose.pitch = randomPitch;
        doorClose.gameObject.transform.position = pos;
        doorClose.Play();
    }


    //SCREAMER SFX
    public void PlayScreamer1()
    {
        screamer1.volume = volumenDeseadoScreamer;   //para resetear el volumen en caso de que otro metodo lo haya alterado
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




    //LINTERNA ON/OFF
    public void PlayLinternaOn()
    {
        linternaOn.Play();
    }
    public void PlayLinternaOff()
    {
        linternaOff.Play();
    }




    //PASOS
    public void PlayPasos()
    {
        if (pasos1.isPlaying == false && pasos2.isPlaying == false) //solo da play si no estaba sonando ya
        {
            float randomPitch = Random.Range(0.95f, 1.05f); // para un poquito de variedad
            int randomClip = Random.Range(0, 2); // 50/50 chances de reproducir uno o el otro
            if (randomClip == 0)
            {
                pasos1.pitch = randomPitch;
                pasos1.Play();
            }
            else
            {
                pasos2.pitch = randomPitch;
                pasos2.Play();
            }
        }
    }
    public void StopPasos()
    {
        pasos1.Stop();
        pasos2.Stop();
    }



    //SALTO
    public void PlayJumpUp()
    {
        if (!jumpUp.isPlaying)
        {
            float randomPitch = Random.Range(0.95f, 1.05f); 
            jumpUp.pitch = randomPitch;
            jumpUp.Play();
            jumpDownIsReady = true;
        }
    }
    public void PlayJumpDown()
    {
        if (jumpDownIsReady)
        {
            if (!jumpDown.isPlaying)
            {
                float randomPitch = Random.Range(0.95f, 1.05f);
                jumpDown.pitch = randomPitch;
                jumpDown.Play();
                jumpDownIsReady = false;
            }
        }
    }
}
