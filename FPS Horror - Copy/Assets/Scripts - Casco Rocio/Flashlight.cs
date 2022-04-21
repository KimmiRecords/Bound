using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{

    //LOGICA DE LA LINTERNA, POR MEI

    public bool flashlightActive = false;
    public Text textTimer;
    public GameObject flashlight;
    public GameObject flashlightActivatingCollider;
    public FlashlightLife flashlightOff; //re cheto, llama al otro script


    void Start()
    {
        flashlight.SetActive(false);
        flashlightActivatingCollider.SetActive(false);
    }

    void Update()
    {
        FlashlightFunction();
    }

    public void FlashlightFunction()
    {
        if (flashlightOff.timer > 0 && Input.GetKeyDown(KeyCode.Q) && PlayerStats.hasFlashlight == true) //toco Q para prender/apagar la linterna, si me queda timer
        {
            flashlightActive = !flashlightActive;

            if (flashlightActive == true)
            {
                flashlight.SetActive(true);
                flashlightActivatingCollider.SetActive(true);
                AudioManager.instance.PlayLinternaOn();
            }
            else if (flashlightActive == false)
            {
                flashlight.SetActive(false);
                flashlightActivatingCollider.SetActive(false);
                AudioManager.instance.PlayLinternaOff();
            }
        }

    }




}