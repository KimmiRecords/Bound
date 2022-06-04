using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLights : MonoBehaviour
{
    //las biglights son las luces de la sala de las capsulas
    //se prenden todas juntas cuando entras a la sala, secuencialmente. hacen ruido tambien.

    //este script se lo adjuntas al trigger, cuando lo atravesas hace todo esto
    //por diego katabian

    [SerializeField]
    protected Light[] luces;

    [SerializeField]
    protected float intensidadDeseada;

    [SerializeField]
    protected float intervalTime;

    [SerializeField]
    protected bool yaPrendiLasLuces = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if (!yaPrendiLasLuces)
            {
                StartCoroutine(StartTurnOn());
            }

            print("entre al trigger");
        }
    }

    //void TurnOn()
    //{
    //    for (int i = 0; i < luces.Length; i++)
    //    {
    //        luces[i].intensity = intensidadDeseada;
    //    }
    //}

    public IEnumerator StartTurnOn()
    {
        print("start turn on");
        yaPrendiLasLuces = true;

        AudioManager.instance.PlayBigLightSwitch();
        for (int i = 0; i < 2; i++)
        {
            luces[i].intensity = intensidadDeseada;
        }
        yield return new WaitForSeconds(intervalTime);

        AudioManager.instance.PlayBigLightSwitch();
        for (int i = 2; i < 4; i++)
        {
            luces[i].intensity = intensidadDeseada;

        }
        yield return new WaitForSeconds(intervalTime);

        AudioManager.instance.PlayBigLightSwitch();
        for (int i = 4; i < 6; i++)
        {
            luces[i].intensity = intensidadDeseada;
        }
        yield return new WaitForSeconds(intervalTime);

        AudioManager.instance.PlayBigLightSwitch();
        for (int i = 6; i < 8; i++)
        {
            luces[i].intensity = intensidadDeseada;
        }
        yield return new WaitForSeconds(intervalTime);

        AudioManager.instance.PlayBigLightSwitch();
        for (int i = 8; i < 10; i++)
        {
            luces[i].intensity = intensidadDeseada;
        }
        yield return new WaitForSeconds(intervalTime);

        Destroy(this.gameObject);
    }
}
