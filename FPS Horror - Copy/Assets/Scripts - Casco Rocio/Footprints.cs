using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public GameObject     footprints;
    public GameObject     seeFootprints;
    public FlashlightLife timerLife;
    bool                  activator;

    void Start()
    {
        footprints.SetActive(false);
        seeFootprints.SetActive(false);
    }


    void Update()
    {
        if (timerLife.timer > 0 && Input.GetKeyDown(KeyCode.Q) && PlayerStats.hasFlashlight == true)
        {
            activator = !activator;
            if (activator)
            {
                footprints.SetActive(true);

            }
            else if (!activator)
            {
                footprints.SetActive(false);
            }
        }
        else if (timerLife.timer <= 0)
        {
            footprints.SetActive(false);
        }



    }
}
