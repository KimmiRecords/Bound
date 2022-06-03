using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanel : DoorControllerButton
{
    public GameObject winTrigger;
    public override void Interact()
    {
        if (PlayerStats.instance.UsbsCollected == 4)
        {
            base.Interact();
            winTrigger.SetActive(true);
            //PlayerStats.instance.Win();
        }
        else
        {
            AudioManager.instance.PlayAccessDenied();
            print("no tenes permiso para operar este panel");
        }
    }
}
