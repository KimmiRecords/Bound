using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardKeyPickup : Collectables
{
    //cuando agarras la llave, te da acceso a operar con paneles
    //por diego katabian

    public override void Interact()
    {
        PlayerStats.instance.GetCardKey();
        base.Interact();
    }
 
}
