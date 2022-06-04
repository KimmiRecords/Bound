using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalUSB : MonoBehaviour
{
    //este script agrega funciones especiales al ultimo USB que agarras
    //por diego katabian

    public AlarmLight[] lights; //las luces que voy a iniciar

    public ToxicGas[] toxicGases;

    public Dialogue[] dialogues;
    
    //void OnDestroy()
    //{
    //    if (!this.gameObject.scene.isLoaded) 
    //    {
    //        return;
    //    }

    //    AudioManager.instance.StopAlarmaNorway(); //reproduzco la alarma heavy
    //    AudioManager.instance.PlayAlarmaTriple();

    //    for (int i = 0; i < lights.Length; i++)
    //    {
    //        lights[i].gameObject.SetActive(true); //prendo las luces de alarma
    //    }

    //    for (int i = 0; i < toxicGases.Length; i++)
    //    {
    //        toxicGases[i].gameObject.SetActive(true); //prendo los extra gases
    //    }

    //    for (int i = 0; i < dialogues.Length; i++)
    //    {
    //        dialogues[i].gameObject.SetActive(true);
    //    }
    //}

    void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded)
        {
            return;
        }

        AudioManager.instance.StopAlarmaNorway(); //reproduzco la alarma heavy
        AudioManager.instance.PlayAlarmaTriple();

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].gameObject.SetActive(true); //prendo las luces de alarma
        }

        for (int i = 0; i < toxicGases.Length; i++)
        {
            toxicGases[i].gameObject.SetActive(true); //prendo los extra gases
        }

        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogues[i].gameObject.SetActive(true);
        }
    }
}
