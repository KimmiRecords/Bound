using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTrigger : MonoBehaviour
{
    //este script se lo pones a una pressure plate para que prenda UNA luz

    private BoxCollider boxCollider;
    public Light luz; //la luz que voy a prender. 
    public float intensidadDeseada;

    void Start()
    {
        if (GetComponent<BoxCollider>() != null)
        {
            boxCollider = GetComponent<BoxCollider>();
        }
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas, la 3 es player
        {
            //prende la luz
            luz.intensity = intensidadDeseada;
            AudioManager.instance.pPlateOn.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            //apaga la luz
            luz.intensity = 0;
            AudioManager.instance.pPlateOff.Play();

        }
    }
}
