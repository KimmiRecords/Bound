using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightButton : DoorControllerButton
{
    //las puertas cerradas tienen una luz roja
    //este script se lo pones a un boton que abre puertas para que la haga verde
    //es hijo de doorcontroller, por lo que tambien abre puertas
    //TP2 - Francisco Serra y Diego Katabian

    [SerializeField]
    protected Light[] luces; //las luces que quiero prender
    public Color rojo;
    public Color verde;

    public bool _yaPrendiLasLuces;

 
    void Start()
    {
        _yaPrendiLasLuces = false;
    }

    public override void Interact()
    {
        base.Interact();
        if (access)
        {
            if (!_yaPrendiLasLuces)
            {
                TurnGreen();
                _yaPrendiLasLuces = true;
            }
            else
            {
                TurnRed();
                _yaPrendiLasLuces = false;
            }
        }
    }

    public void TurnRed()
    {
        for (int i = 0; i < luces.Length; i++)
        {
            luces[i].color = rojo;
        }
    }

    public void TurnGreen()
    {
        for (int i = 0; i < luces.Length; i++)
        {
            luces[i].color = verde;
        }
    }
}

