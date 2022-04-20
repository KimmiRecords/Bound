using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSelector : MonoBehaviour
{


    void Start()
    {
        //AudioManager.instance.PlayMainMenuMusic();
        PlayerStats.usbsCollected = 0;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            //AudioManager.instance.StopMainMenuMusic();
            //AudioManager.instance.PlayBGM();
            SceneManager.LoadScene(4); //instrucciones
        }
    }
}
