using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardKeyPickup : Collectables
{
    //cuando agarras la llave, te da acceso a operar con paneles
    //por diego katabian

    public CardKeyAccess[] cardKeyAccesses; //referencio a los paneles que necesitan esta llave para operar

    public override void Interact()
    {
        PlayerStats.instance.hasCardKey = true; 
        for (int i = 0; i < cardKeyAccesses.Length; i++)
        {
            cardKeyAccesses[i].dcb.access = true; //ahora tengo acceso para operar
            cardKeyAccesses[i].infoPopup.desiredText = cardKeyAccesses[i].textoConCardKey; //cambio el texto que muestran aquellos paneles
        }
        base.Interact();
    }
}
