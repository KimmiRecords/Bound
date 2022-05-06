using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBPickup : Interactable
{
    public override void Interact()
    {
        base.Interact();

        PlayerStats.UsbsCollected++;
        print("Conseguiste un Pendrive. Solo te faltan " + (4 - PlayerStats.UsbsCollected) + " para ganar.");

        Destroy(this.gameObject, 0.1f); //como es un pickup, lo destruyo

    }
}
