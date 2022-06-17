using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTrigger : MonoBehaviour
{
    //este script se lo pones a un collider para que prenda n luces CUANDO y MIENTRAS lo pisas
    //lo uso para prender luces con placas de presion
    //por diego katabian

    [SerializeField]
    protected float intensidadDeseada; //intensidad de la luz

    [SerializeField]
    protected Light[] luces; //las luces que quiero prender

    [SerializeField]
    protected bool haceRuido;

    [SerializeField]
    protected bool lasDejaPrendidas; //si las deja prendidas o las apaga cuando salis del plate

    BoxCollider _boxCollider;
    bool _yaPrendiLasLuces;



    void Start()
    {
        if (GetComponent<BoxCollider>() != null)
        {
            _boxCollider = GetComponent<BoxCollider>();
        }
        _yaPrendiLasLuces = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas, la 3 es player
        {
            TurnOnLights();

            _yaPrendiLasLuces = true;

            if (haceRuido)
            {
                AudioManager.instance.PlayPPlateOn(transform.position);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) 
        {
            if (!_yaPrendiLasLuces) //en el stay, solo las prende si estaban apagadas. 
            {
                TurnOnLights();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            if (!lasDejaPrendidas) //si no las tiene que dejar prendidas, las apaga.
            {
                TurnOffLights();

                if (haceRuido)
                {
                    AudioManager.instance.PlayPPlateOff(transform.position);
                }

                _yaPrendiLasLuces = false;
            }
        }
    }

    public void TurnOnLights()
    {
        for (int i = 0; i < luces.Length; i++)
        {
            luces[i].intensity = intensidadDeseada;
        }
    }

    public void TurnOffLights()
    {
        for (int i = 0; i < luces.Length; i++)
        {
            luces[i].intensity = 0;
        }
    }

}
