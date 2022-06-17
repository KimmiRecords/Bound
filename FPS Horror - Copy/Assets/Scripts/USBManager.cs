using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBManager : MonoBehaviour
{
    //por ahora
    //este script organiza los usbs en un array, para prenderlos y apagarlos segun los agarro

    //mas adelante
    //cuando me muero, re-habilita los usbs que haya capturado entre el ultimo checkpoint y mi muerte

    //por diego katabian

    public static USBManager instance;
    public GameObject[] allUsbs;
    bool[] areCollected;

    [HideInInspector]
    public int usbsAtCheckpoint;

    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        areCollected = new bool[allUsbs.Length];

        for (int i = 0; i < allUsbs.Length; i++)
        {
            areCollected[i] = false;
            //print(allUsbs[i]);
            //print(areCollected[i]);
        }

        //PlayerStats.instance.OnDeath += ResetUSBs;
    }

    public void AddUsb(GameObject usb)
    {
        int index;
        index = System.Array.IndexOf(allUsbs, usb); //index es la posicion del usb que agarre en el gran array de usbs

        areCollected[index] = true; //hago true que agarre ESE usb
        //allUsbs[index].SetActive(false); //deshabilito ese usb
        //print("agarre el usb " + index);
    }

    public void ResetUSBs(Vector3 cp) 
    {
        PlayerStats.instance.UsbsCollected = usbsAtCheckpoint; //vuelvo a tener usbs como tenia al momento del checkpoint

        for (int i = usbsAtCheckpoint; i < allUsbs.Length; i++)
        {
            allUsbs[i].SetActive(true); //re-habilito los usb que no tenia al momento del checkpoint
            //print("active el usb " + i);
        }
    }
}
