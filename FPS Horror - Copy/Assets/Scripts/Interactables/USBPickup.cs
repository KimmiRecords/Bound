using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBPickup : Interactable
{
    public override void Interact()
    {
        base.Interact();

        PlayerStats.instance.UsbsCollected++;
        print("Conseguiste un Pendrive. Solo te faltan " + (4 - PlayerStats.instance.UsbsCollected) + " para ganar.");

        Destroy(this.gameObject, 0.1f); //como es un pickup, lo destruyo

    }
}
