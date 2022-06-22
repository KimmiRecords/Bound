using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviBox : MonoBehaviour, IRalentizable
{
    //este script se lo adjuntas a una caja que tenga gravedad loca.
    //acordate de cargar en el inspector qué interactable le va a togglear la grav, y cuales son sus gravedad normal y loca.

    //TP2 - Valentino Roman y Diego Katabian

    [Tooltip("La gravedad normal y alterada para esta caja.")]
    public GraviStruct graviStruct;

    Vector3 _appliedGrav;
    Rigidbody _rb;
    bool _isBound;
    float _speedModifier;

    void Start()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            _rb = GetComponent<Rigidbody>();
        }

        _speedModifier = 1;
        _appliedGrav = graviStruct.normalGrav;
        _isBound = true;
        _rb.useGravity = false;
    }

    void FixedUpdate()
    {
        _rb.AddForce(_appliedGrav * _speedModifier, ForceMode.Force); //aplica appliedGrav constantemente
    }

    public void ToggleGrav()
    {
        if (_isBound)
        {
            _appliedGrav = graviStruct.alteredGrav; //suelto a la caja para que flote (altero la grav)
            _isBound = false;
        }
        else
        {
            _appliedGrav = graviStruct.normalGrav; //la vuelvo a la normalidad
            _isBound = true;
        }
    }

    public void EnterSlow()
    {
        _speedModifier = 0.1f;
    }

    public void ExitSlow()
    {
        _speedModifier = 1;
    }
}
