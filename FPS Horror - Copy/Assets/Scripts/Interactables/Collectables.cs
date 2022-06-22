using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : Interactable
{
    //los collectables son un tipo de interactable cuyo objeto se destruye y cuya imagen se agrega al inventario
    //por diego katabian

    public override void Interact()
    {
        base.Interact(); //el base es solo reproducir un sfx

        GameObject itemPickedUp = this.gameObject; //que objeto agarre
        Items item = itemPickedUp.GetComponent<Items>(); //su componente item
        inventory.AddItem(itemPickedUp, item.id, item.type, item.icon); //lo agrego. 
    }
}
