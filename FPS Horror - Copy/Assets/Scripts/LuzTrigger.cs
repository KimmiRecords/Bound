using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTrigger : MonoBehaviour
{
    //este script se lo pones a un collider para que prenda n luces MIENTRAS lo pisas
    //lo uso para prender luces con placas de presion
    //por diego katabian

    
    public float intensidadDeseada;
    public Light[] luces; //las luces que quiero prender
    public bool haceRuido;

    BoxCollider boxCollider;
    bool yaPrendiLasLuces;


    void Start()
    {
        if (GetComponent<BoxCollider>() != null)
        {
            boxCollider = GetComponent<BoxCollider>();
        }
        yaPrendiLasLuces = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas, la 3 es player
        {
            //prende las luces
            for (int i = 0; i < luces.Length; i++)
            {
                luces[i].intensity = intensidadDeseada;
            }
            yaPrendiLasLuces = true;

            if (haceRuido)
            {
                AudioManager.instance.PlayPPlateOn(transform.position);
                print("hice ruido luztrigger enter");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) 
        {
            if (!yaPrendiLasLuces) //en el stay, solo las prende si estaban apagadas. 
            {
                for (int i = 0; i < luces.Length; i++)
                {
                    luces[i].intensity = intensidadDeseada;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            //apaga la luces
            for (int i = 0; i < luces.Length; i++)
            {
                luces[i].intensity = 0;
            }

            if (haceRuido)
            {
                AudioManager.instance.PlayPPlateOff(transform.position);
                print("hice ruido luztrigger exit");

            }

            yaPrendiLasLuces = false;
        }
    }
}
