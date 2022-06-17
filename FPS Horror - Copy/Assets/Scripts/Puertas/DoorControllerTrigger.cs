using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerTrigger : MonoBehaviour
{
    //este script se lo adjuntas a una placa de presion roja para que abra una puerta.
    //por fran y dk

    public DoorController quePuertaAbro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas, la 3 es player
        {
            AudioManager.instance.PlayPPlateOn(transform.position);
            //print("hice ruido doortrigger enter" + other);

            quePuertaAbro.OpenDoor();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas, la 3 es player
        {
            if (!quePuertaAbro._doorAnim.GetBool("isOpening")) //en el stay, la abre solo si no esta abierta. esto evita que se bugee cuando hay 2 cajas o caja+player en la placa
            {
                quePuertaAbro.OpenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            AudioManager.instance.PlayPPlateOff(transform.position);
            //print("hice ruido doortrigger exit" + other);
            quePuertaAbro.CloseDoor();
        }
    }
}
