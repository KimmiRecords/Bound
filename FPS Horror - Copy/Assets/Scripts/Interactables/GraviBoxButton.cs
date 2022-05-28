using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviBoxButton : Interactable
{
    //este script se lo agregas a un boton para que altere la gravedad de cajas
    //por valentino roman y diego katabian

    public GraviBox[] graviBoxes; //cargamos en el inspector que cajas seran controlas por este boton

    public override void Interact()
    {
        base.Interact();

        for (int i = 0; i < graviBoxes.Length; i++)
        {
            graviBoxes[i].ToggleGrav();
        }
    }
}
