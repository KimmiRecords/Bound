using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : Collectables
{
    //cuando tocas E, levantas la linterna y desaperece el chebola colgante.
    //tambien hace aparecer un texto informativo
    //TP2 - Diego Katabian

    public GameObject chebolaCrux;
    public InfoPopupOneTime pressQ;

    public override void Interact()
    {
        PlayerStats.instance.GetFlashlight();

        if (chebolaCrux != null)
        {
            Destroy(chebolaCrux, 0.1f); //destruye al chebola colgado
        }

        if (pressQ != null)
        {
            pressQ.gameObject.SetActive(true);
        }
        base.Interact();
    }
}

