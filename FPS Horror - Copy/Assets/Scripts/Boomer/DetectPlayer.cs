using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    //este script detecta al player y cambia la bool para ser usada por otros scripts.
    //se la adjunto al collider de explosion del monstruo patrullador para que detecte al player con una caja de colision distinta a la propia del monstruo.
    //por diego katabian y francisco serra

    public bool playerIsInRange;

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
}
