using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : Interactable
{
    //cuando tocas E, levantas la linterna y desaperece el chebola colgante. 

    public GameObject chebolaCrux;
    public override void Interact()
    {
        base.Interact();

        PlayerStats.hasFlashlight = true; //obtengo la linterna
        print("Conseguiste la linterna. Toca Q para ver.");

        Destroy(chebolaCrux, 0.1f); //destruye al chebola colgado
        Destroy(this.gameObject, 0.1f); //como es un pickup, lo destruyo

    }
}
