using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosSFX : MonoBehaviour
{
    public CharacterController charController;

    void Start()
    {
        
    }

    void Update()
    {
        if (charController.isGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                AudioManager.instance.PlayPasos();
            }
        }
        else
        {
            AudioManager.instance.StopPasos();
        }





    }
}
