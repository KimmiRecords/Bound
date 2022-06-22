using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasManager : MonoBehaviour
{
    //este script administra los gases y recibe eventos
    //TP2 - Mateo Palma y Diego Katabian


    [Tooltip("Los gases que queres que se prendan en el FinalUSB")]
    public ToxicGas[] finalUsbGases;
    public FinalUSB finalUsb;

    private void Start()
    {
        finalUsb.OnFinalUSBPickup += TurnOnGases; //suscribo mi turnongases al evento 
    }

    public void TurnOnGases()
    {
        for (int i = 0; i < finalUsbGases.Length; i++)
        {
            finalUsbGases[i].gameObject.SetActive(true);
        }
    }
}