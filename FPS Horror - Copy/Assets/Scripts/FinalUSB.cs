using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalUSB : MonoBehaviour
{
    //este script agrega funciones especiales al ultimo USB que agarras
    //por diego katabian

    public AlarmLight[] lights; //las luces que voy a iniciar
    
    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) 
        {
            return;
        }

        AudioManager.instance.StopAlarmaNorway();
        AudioManager.instance.PlayAlarmaTriple();

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].gameObject.SetActive(true);
        }

    }
}
