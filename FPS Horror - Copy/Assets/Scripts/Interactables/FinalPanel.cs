using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanel : DoorLightButton
{
    //este es un doorControllerButton especial nomas
    //TP2 - Francisco Serra y Diego Katabian

    public WinTrigger winTrigger;

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

            if (!_yaPrendiLasLuces)
            {
                TurnGreen();
                _yaPrendiLasLuces = true;
            }
            else
            {
                TurnRed();
                _yaPrendiLasLuces = false;
            }

            if (!winTrigger.gameObject.activeSelf)
            {
                winTrigger.gameObject.SetActive(true);
            }
        }
        else
        {
            AudioManager.instance.PlayAccessDenied();
        }
    }
}
