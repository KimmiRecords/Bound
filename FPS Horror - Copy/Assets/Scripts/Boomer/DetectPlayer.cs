using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    //este script hace lo que dice que hace. adjuntasela al monstruo patrullador.
    //por diego katabian y francisco serra

    public LayerMask playerMask;
    public float sightRange;

    public bool playerIsInRange;

    void Update()
    {
        //playerIsInRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            playerIsInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            playerIsInRange = false;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, sightRange);
    }
}
