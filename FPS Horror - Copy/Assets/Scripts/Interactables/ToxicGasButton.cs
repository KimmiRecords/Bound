using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasButton : Interactable
{
    //los botones de toxicGas funcionan solo una vez. los tocas y no sirven mas.
    //por dk

    public ToxicGas[] queGasesApago;

    public override void Interact()
    {
        base.Interact();

        for (int i = 0; i < queGasesApago.Length; i++) //destruyo cada gas
        {
            Destroy(queGasesApago[i].gameObject); 
            print("destrui el gas" + queGasesApago[i]);
        }

        Destroy(this.gameObject); //destruyo este boton para que quede deshabilitado y ya no se pueda pulsar.
    }
}
