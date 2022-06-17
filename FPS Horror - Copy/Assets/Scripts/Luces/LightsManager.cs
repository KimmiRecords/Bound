using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    //este script se lo adjuntas a un objeto lightsmanager para que apague y prenda luces que estan lejos del jugador.
    //ademas, la idea es mas adelante optimizar recursos y reducir la cantidad de luces realtime a renderear.
    //por diego katabian

    public Light luzAlarma;
    public FinalUSB finalUsb;

    private void Start()
    {
        finalUsb.OnFinalUSBPickup += TurnOnAlarm;
    }

    public void TurnOnAlarm()
    {
        luzAlarma.gameObject.SetActive(true);
    }










    //public LayerMask playerMask; //en inspector le indico cual es la layer del player, y la distancia a considerar para prender/apagar luces.
    //public float radio;

    //Light[] allLights; //el array de todas las luces
    //List<Light> rtLights = new List<Light>(); //la lista con solo las realtime
    //bool[] playerInRange; //para cada luz realtime, si el player esta en rango o no

    //void Start()
    //{
        //allLights = FindObjectsOfType<Light>(); //lleno el array de todas las luces activas al start

        //for (int i = 0; i < allLights.Length; i++)
        //{
        //    //if (allLights[i].lightmapBakeType == LightmapBakeType.Realtime)
        //    //{
        //    //    rtLights.Add(allLights[i]); //lleno la lista solo con las que son realtime
        //    //}
        //    print(allLights[i]);
        //}

        //playerInRange = new bool[rtLights.Count]; //lleno el array de bools
    //}

    //private void Update()
    //{
    //    CheckPlayer(); //constantemente chequea si el player esta cerca o lejos
    //    for (int i = 0; i < playerInRange.Length; i++) //constantemente prende o apaga TODAS. no parece muy optimo la verdad. se puede mejorar?
    //    {
    //        if (playerInRange[i])
    //        {
    //            TurnOnLight(rtLights[i]);
    //        }
    //        else
    //        {
    //            TurnOffLight(rtLights[i]);
    //        }
    //    }
    //}

    //public void TurnOffLight(Light l)
    //{
    //    l.gameObject.SetActive(false);
    //}

    //public void TurnOnLight(Light l)
    //{
    //    l.gameObject.SetActive(true);
    //}

    //public void CheckPlayer()
    //{
    //    for (int i = 0; i < rtLights.Count; i++) //para cada luz realtime, me fijo si el player esta en rango, y seteo el bool.
    //    {
    //        if (Physics.CheckSphere(rtLights[i].transform.position, radio, playerMask)) //uso el radio y el player mask para chequear
    //        {
    //            playerInRange[i] = true;
    //        }
    //        else
    //        {
    //            playerInRange[i] = false;
    //        }
    //    }
    //}
}
