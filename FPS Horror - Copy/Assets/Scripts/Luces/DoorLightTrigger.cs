using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightTrigger : MonoBehaviour
{
    //las puertas cerradas tienen una luz roja
    //este script se lo pones a un collider para que la haga verde
    //por diego katabian

    [SerializeField]
    protected Light[] luces; //las luces que quiero prender
    public Color rojo = new Color(225/255, 70/255, 70/255, 1);
    public Color verde = new Color(125/255, 255/255, 125/255, 1);

    BoxCollider _boxCollider;
    bool _yaPrendiLasLuces;



    void Start()
    {
        if (GetComponent<BoxCollider>() != null)
        {
            _boxCollider = GetComponent<BoxCollider>();
        }
        _yaPrendiLasLuces = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas, la 3 es player
        {
            TurnGreen();
            _yaPrendiLasLuces = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            if (!_yaPrendiLasLuces) //en el stay, solo las prende si estaban apagadas. 
            {
                TurnGreen();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3)
        {
            TurnRed();
            _yaPrendiLasLuces = false;
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

