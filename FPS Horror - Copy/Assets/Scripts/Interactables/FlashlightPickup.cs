using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : Interactable
{
    public override void Interact()
    {
        base.Interact();

        PlayerStats.hasFlashlight = true;
        print("Conseguiste la linterna. Toca Q para ver.");

        Destroy(this.gameObject, 0.1f); //como es un pickup, lo destruyo

    }
}
