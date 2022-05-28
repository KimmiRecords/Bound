using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerButton : Interactable
{
    //este script se lo agregas a una consola para que abra una puerta
    //por francisco serra y diego katabian

    public DoorController quePuertaAbro;

    [HideInInspector]
    public bool access = false;

    public override void Interact() //los doorControllerbutton polimorfean el metodo base, y hacen esto cuando los interactuas con E.
    {
        if (access)
        {
            base.Interact(); //el base es reproducir audio nomas

            if (quePuertaAbro._doorAnim.GetBool("isOpening"))
            {
                quePuertaAbro.CloseDoor();
            }
            else
            {
                quePuertaAbro.OpenDoor();
            }
        }
        else
        {
            AudioManager.instance.PlayAccessDenied();
            print("no tenes permiso para operar este panel");
        }

    }
}
