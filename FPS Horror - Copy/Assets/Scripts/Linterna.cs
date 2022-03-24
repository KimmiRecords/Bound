using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public bool prendida;
    public Light luz;
    void Start()
    {
        //Este script prende y apaga la linterna con Q. 
        //Agrega este script a cada luz que quieras apagar/prender con Q

        if (GetComponent<Light>() != null)
        {
            luz = GetComponent<Light>();
        }
    }

    void Update()
    {
        //if (PlayerStats.agency) //agency es true solo cuando tenemos control de pj
        //{                       //cosa de que estes comandos no funcionen en cutscenes o intro
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (prendida)
                {
                    prendida = false;
                }
                else
                {
                    prendida = true;
                }
            }

        //}

        if (prendida)
        {
            luz.intensity = 0.8f;
        }
        else
        {
            luz.intensity = 0f;
        }
    }
}
