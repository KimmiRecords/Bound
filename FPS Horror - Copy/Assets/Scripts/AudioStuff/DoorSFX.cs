using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSFX : MonoBehaviour
{
    //el animator es un tipo jodido y solo puede disparar metodos de scripts de su propio objeto. no puede llamar a otros scripts.
    //este script se lo agregas a una puerta para que su animator pueda disparar el openDoorSFX.
    //este script y el animator DEBEN estar en el mismo objeto.


    public void PlayDoorOpen()
    {
        AudioManager.instance.PlayDoorOpen(transform.position);
    }

    public void PlayDoorClose()
    {
        AudioManager.instance.PlayDoorClose(transform.position);
    }
}
