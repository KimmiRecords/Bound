using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasButton : Interactable
{
    //los botones de toxicGas funcionan solo una vez. los tocas y no sirven mas.
    //por dk
    public ToxicGas queGasApago;

    public override void Interact()
    {
        base.Interact();
        print("soy un toxicGasButton");

        Destroy(queGasApago.gameObject); //destruyo al gas
        print("destrui el gas");

        Destroy(this.gameObject); //destruyo este boton para que quede deshabilitado y ya no se pueda pulsar.
    }
}
