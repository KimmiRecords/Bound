using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{

    //LOGICA DE LA LINTERNA, POR MEI
    private bool           flashlightActive = false;
    public  Text           textTimer;
    public GameObject flashlight;
    public  GameObject     flashlightPoint;
    public  GameObject     flashlightActivatingCollider;
    public  FlashlightLife flashlightOff; //re cheto, llama al otro script


    
    public bool activate = true;

    

    void Start()
    {
        flashlight.SetActive(false);
        flashlightPoint.SetActive(false);
        flashlightActivatingCollider.SetActive(false);
    }

    void Update()
    {
        FlashlightFunction();
    }

    public void FlashlightFunction()
    {
        if (flashlightOff.timer > 0 && Input.GetKeyDown(KeyCode.Q) && PlayerStats.instance.hasFlashlight == true && activate == true) //toco Q para prender/apagar la linterna, si me queda timer
        {
            flashlightActive = !flashlightActive;
            

            if (flashlightActive == true)
            {
                flashlightPoint.SetActive(true);
                flashlightActivatingCollider.SetActive(true);
                AudioManager.instance.PlayLinternaOn();
            }
            else if (flashlightActive == false)
            {
                flashlightPoint.SetActive(false);
                flashlightActivatingCollider.SetActive(false);
                AudioManager.instance.PlayLinternaOff();
            }
        }

    }





    public void Object()
    {
        activate = !activate;

        if (PlayerStats.instance.hasFlashlight && activate == true)
        {
            flashlight.SetActive(true);

        }
        else if (PlayerStats.instance.hasFlashlight && activate == false)
        {

            flashlight.SetActive(false);

        }
    }
}