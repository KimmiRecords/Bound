using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSelector : MonoBehaviour
{
    //void Start()
    //{
    //    PlayerStats.instance.UsbsCollected = 0;
    //}

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("InstructionsScene"); //instrucciones
        }
    }
}
