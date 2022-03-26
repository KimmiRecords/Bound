using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public bool flashlightActive = false;
    public Text textTimer;
    public GameObject flashlight;
    public GameObject flashlightActivatingCollider;
    public FlashlightLife flashlightOff;


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
        if (flashlightOff.timer > 0 && Input.GetKeyDown(KeyCode.E))
        {
            flashlightActive = !flashlightActive;

            if (flashlightActive == true)
            {
                flashlight.SetActive(true);
                flashlightActivatingCollider.SetActive(true);

            }
            else if (flashlightActive == false)
            {
                flashlight.SetActive(false);
                flashlightActivatingCollider.SetActive(false);
            }
        }

    }




}