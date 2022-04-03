using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Vector3 posicionAlzada;
    public Vector3 posicionInicial;
    public GameObject gate;
    void Start()
    {
        if (boxCollider != null)
        {
            boxCollider = GetComponent<BoxCollider>();
        }
        posicionAlzada = gate.transform.position + Vector3.up * 10;
        posicionInicial = gate.transform.position;


    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) //la layer 7 es de las cajas 
        {
            gate.transform.position = posicionAlzada;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7) //la layer 7 es de las cajas 
        {
            gate.transform.position = posicionInicial;
        }
    }
}
