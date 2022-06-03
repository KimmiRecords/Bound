using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanel : DoorControllerButton
{
    public GameObject winTrigger;
    public override void Interact()
    {
        if (access && PlayerStats.instance.UsbsCollected == 4)
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

            winTrigger.SetActive(true);
        }
        else
        {
            AudioManager.instance.PlayAccessDenied();
            print("no tenes permiso para operar este panel");
        }
    }
}
