using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardKeyAccess : MonoBehaviour
{
    //este script se lo adjuntas a un fbx panel para que pida llave para abrir la puerta.
    //por diego katabian

    public InfoPopup infoPopup; //el info popup a actualizar
    public DoorControllerButton dcb; //el script, en este mismo objeto
    public string textoSinCardKey;
    public string textoConCardKey;

    void Start()
    {
        infoPopup.desiredText = textoSinCardKey;
    }

    public void GetAccess()
    {
        dcb.access = true; //ahora tengo acceso para operar
        //infoPopup.desiredText = textoConCardKey;
    }

    public void ChangeText()
    {
        infoPopup.desiredText = textoConCardKey;
    }
}
