using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviBoxButton : Interactable
{
    //este script se lo agregas a un boton para que altere la gravedad de cajas
    //por valen y dk

    public GraviBox[] graviBoxes; //cargamos en el inspector que cajas seran controlas por este boton

    public override void Interact()
    {
        base.Interact();
        print("en particular, soy un graviBoxButton");

        for (int i = 0; i < graviBoxes.Length; i++)
        {
            graviBoxes[i].ToggleGrav();
        }
    }
}
