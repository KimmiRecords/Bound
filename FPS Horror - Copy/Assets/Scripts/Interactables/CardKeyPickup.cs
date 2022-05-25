using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardKeyPickup : Interactable
{
    public override void Interact()
    {
        base.Interact();

        PlayerStats.instance.hasCardKey = true;
        print("Conseguiste una llave. Tal vez abra alguna puerta.");

        Destroy(this.gameObject, 0.1f); //como es un pickup, lo destruyo

    }
}
