using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerTrigger : MonoBehaviour
{
    //este script se lo adjuntas a una placa de presion roja para que abra una puerta.

    public DoorController quePuertaAbro;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas, la 3 es player
        {
            AudioManager.instance.pPlateOn.Play();
            quePuertaAbro.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            AudioManager.instance.pPlateOff.Play();
            quePuertaAbro.CloseDoor();
        }
    }
}
