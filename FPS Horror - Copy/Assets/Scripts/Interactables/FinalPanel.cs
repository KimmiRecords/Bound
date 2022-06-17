using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanel : DoorControllerButton
{
    //este es u doorControllerButton especial nomas
    //por diego katabian

    public override void Interact()
    {
        if (access && PlayerStats.instance.UsbsCollected == 4)
        {
            AudioManager.instance.PlayPickup(1.1f);

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
