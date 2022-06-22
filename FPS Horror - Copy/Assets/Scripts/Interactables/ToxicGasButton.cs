using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasButton : Interactable
{
    //los botones de toxicGas funcionan pueden funcionar una sola vez. si son one-time los tocas y no sirven mas.
    //sea ese el caso o no, apagan y prenden gases.
    //TP2 - Diego Katabian

    public ToxicGas[] queGasesApago;
    public bool oneTime; //si es de uno unico o toggle

    bool yaPrendiLosGases = true;


    public override void Interact()
    {
        base.Interact();

        if (!yaPrendiLosGases)
        {
            for (int i = 0; i < queGasesApago.Length; i++) //prendo cada gas
            {
                queGasesApago[i].gameObject.SetActive(true);
                print("active el gas" + queGasesApago[i]);
            }
            yaPrendiLosGases = true;
        }
        else
        {
            for (int i = 0; i < queGasesApago.Length; i++) //apago cada gas
            {
                queGasesApago[i].gameObject.SetActive(false); 
                print("desactive el gas" + queGasesApago[i]);
            }
            yaPrendiLosGases = false;
        }

        if (oneTime)
        {
            Destroy(this.gameObject); //destruyo este boton para que quede deshabilitado y ya no se pueda pulsar.
        }
    }
}
