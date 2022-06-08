using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviBox : MonoBehaviour, IRalentizable
{
    //este script se lo adjuntas a una caja que tenga gravedad loca.
    //acordate de cargar en el inspector qué interactable le va a togglear la grav, y cuales son sus gravedad normal y loca.

    //-por valen y dk

    public Vector3 normalGrav;
    public Vector3 alteredGrav;

    private Vector3 appliedGrav;
    private bool isBound;
    private Rigidbody rb;
    float _speedModifier;

    void Start()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }

        _speedModifier = 1;
        appliedGrav = normalGrav;
        isBound = true;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        rb.AddForce(appliedGrav * _speedModifier, ForceMode.Force); //aplica appliedGrav constantemente
    }

    public void ToggleGrav()
    {
        if (isBound)
        {
            appliedGrav = alteredGrav; //suelto a la caja para que flote (altero la grav)
            isBound = false;
        }
        else
        {
            appliedGrav = normalGrav; //la vuelvo a la normalidad
            isBound = true;
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
