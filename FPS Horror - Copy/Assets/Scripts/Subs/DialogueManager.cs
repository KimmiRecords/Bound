using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //este script administra los triggers de dialogo y de victoria
    //TP2 - Diego Katabian


    [Tooltip("Los dialogos que queres que se prendan en el FinalUSB")]
    public Dialogue[] finalUsbDialogues;
    public WinTrigger winTrigger;
    public FinalUSB finalUsb;
    private void Start()
    {
        finalUsb.OnFinalUSBPickup += TurnOnFinalDialogueTriggers; //nos suscribimossss
    }

    public void TurnOnFinalDialogueTriggers()
    {
        for (int i = 0; i < finalUsbDialogues.Length; i++)
        {
            finalUsbDialogues[i].gameObject.SetActive(true); 
        }

        winTrigger.gameObject.SetActive(true);
    }
}