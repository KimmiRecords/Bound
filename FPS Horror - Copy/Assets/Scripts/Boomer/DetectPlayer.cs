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
        playerIsInRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
    }
}
