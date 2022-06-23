using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggers : MonoBehaviour
{
    //este script se lo adjuntas a un collider. 
    //cuando lo atravesas, dispara un sonido y se autodestruye
    //por diego katabian

    public string soundName;
    public AudioSource sound;
    public float fadeDuration;
    public float initialVolume;
    public float finalVolume;
    public bool isPlay; //si le da play o stop

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) //la 3 es el player
        {
            TriggerAndDestroy();
        }
    }

    public virtual void TriggerAndDestroy()
    {
        AudioManager.instance.TriggerSound(sound, fadeDuration, initialVolume, finalVolume, isPlay);
        Destroy(this.gameObject);
    }
}
