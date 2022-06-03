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
            AudioManager.instance.PlayPickup(1.1f);

            if (quePuertaAbro._doorAnim.GetBool("isOpening"))
            {
                quePuertaAbro.CloseDoor();
                print("cierro la puerta");

            }
            else
            {
                quePuertaAbro.OpenDoor();
                print("abro la puerta");
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
