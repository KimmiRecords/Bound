using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public GameObject []  footprints;
    public GameObject []  seeFootprints;
    public FlashlightLife timerLife;
    public Flashlight boolActivated; //cambio
    bool                  activator;

    void Start()
    {
        footprints[0].SetActive(false);
        footprints[1].SetActive(false);
        footprints[2].SetActive(false);
        seeFootprints[0].SetActive(false);
        seeFootprints[1].SetActive(false);
        seeFootprints[2].SetActive(false);
    }


    void Update()
    {
        if (timerLife.timer > 0 && Input.GetKeyDown(KeyCode.Q) && PlayerStats.instance.hasFlashlight == true && boolActivated.activate == true) //cambio ultimo
        {
            activator = !activator;
            if (activator)
            {
                footprints[0].SetActive(true);
                footprints[1].SetActive(true);
                footprints[2].SetActive(true);
            }
            else if (!activator)
            {
                footprints[0].SetActive(false);
                footprints[1].SetActive(false);
                footprints[2].SetActive(false);
            }
        }
        else if (timerLife.timer <= 0)
        {
            footprints[0].SetActive(false);
            footprints[1].SetActive(false);
            footprints[2].SetActive(false);
        }
    }
}
