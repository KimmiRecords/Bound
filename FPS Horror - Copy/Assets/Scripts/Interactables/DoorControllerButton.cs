using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerButton : Interactable
{
    //este script se lo agregas a una consola para que abra una puerta
    //TP2 - Francisco Serra y Diego Katabian

    public DoorController quePuertaAbro;

    [HideInInspector]
    public bool access = false;

    public override void Interact()
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
        }

    }
}
