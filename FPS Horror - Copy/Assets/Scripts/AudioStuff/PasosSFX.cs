using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosSFX : MonoBehaviour
{
    //este script se lo pones al player para que sus pasos hagan ruido
    public CharacterController charController;

    void Update()
    {
        if (charController.isGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                AudioManager.instance.PlayPasos();
            }
            else
            {
                AudioManager.instance.StopPasos();
            }
        }
        else
        {
            AudioManager.instance.StopPasos();
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            AudioManager.instance.StopPasos();
        }
    }
}
