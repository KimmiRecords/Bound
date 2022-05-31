using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloInfo : Interactable
{
    // este script se lo adjuntas a los objetos que son solo info. son interactables de clase, pero no hay interaccion real con ellos de gameplay. solo dan info.
    //tuve que hacer este script porque Interactable es una clase abstracta y no se la podes adjuntar a un gameobject.
    //por diego katabian

    public override void Interact()
    {
        print("no hay nada para interactuar con este objeto");
    }
}
