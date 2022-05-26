using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardKeyPickup : Interactable
{
    public CardKeyAccess cardKeyAccess; //referencio al panel que necesita esta llave para operar
    public override void Interact()
    {
        base.Interact();

        PlayerStats.instance.hasCardKey = true;
        cardKeyAccess.dcb.access = true; //ahora tengo acceso para operar
        cardKeyAccess.infoPopup.desiredText = cardKeyAccess.textoConCardKey; //cambio el texto que muestra aquel panel

        print("Conseguiste una llave. Tal vez abra alguna puerta.");

        Destroy(this.gameObject, 0.1f); //como es un pickup, lo destruyo

    }
}
