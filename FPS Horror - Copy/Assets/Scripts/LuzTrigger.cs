using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTrigger : MonoBehaviour
{
    //este script se lo pones a la pressure plate que prende la luz

    public BoxCollider boxCollider;
    public Light luz;

    void Start()
    {
        if (GetComponent<BoxCollider>() != null)
        {
            boxCollider = GetComponent<BoxCollider>();
        }
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas 
        {
            //prende la luz
            luz.intensity = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3) //la layer 7 es de las cajas 
        {
            //apaga la luz
            luz.intensity = 0;
        }
    }
}
