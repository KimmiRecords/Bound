using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerButton : Interactable
{
    //este script se lo agregas a una consola para que abra una puerta
    //por fran y dk

    public DoorController quePuertaAbro;

    [HideInInspector]
    public bool access = false;

    public override void Interact() //los doorControllerbutton polimorfean el metodo base, y hacen esto cuando los interactuas con E.
    {
        base.Interact(); //el base es reproducir audio nomas
        print("en particular, soy un doorControllerButton");

        if (access)
        {
            if (quePuertaAbro._doorAnim.GetBool("isOpening"))
            {
                quePuertaAbro.CloseDoor();
                print("cerre la puerta");
            }
            else
            {
                quePuertaAbro.OpenDoor();
                print("abri la puerta");
            }
        }
        else
        {
            print("no tenes permiso para operar este panel");
        }

    }
}
