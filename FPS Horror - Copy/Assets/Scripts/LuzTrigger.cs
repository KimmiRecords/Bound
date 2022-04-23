using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTrigger : MonoBehaviour
{
    //este script se lo pones a una pressure plate para que prenda UNA luz

    private BoxCollider boxCollider;
    public Light luz; //la luz que voy a prender. 
    public float intensidadDeseada;

    public AudioClip pPlateOnClip;
    public AudioClip pPlateOffClip;

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

            //AudioManager.instance.pPlateOn.Play();
            AudioSource.PlayClipAtPoint(pPlateOnClip, transform.position);
            print("le di play al plateOn en " + transform.position);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            //apaga la luz
            luz.intensity = 0;

            //AudioManager.instance.pPlateOff.Play();
            AudioSource.PlayClipAtPoint(pPlateOffClip, transform.position);
            print("le di play al plateOff en " + transform.position);



        }
    }
}
