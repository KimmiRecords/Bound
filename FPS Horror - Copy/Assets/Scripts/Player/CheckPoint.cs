using UnityEngine;
using System.Collections;
public class CheckPoint : MonoBehaviour
{
    public ParticleSystem particulas;
    bool triggered;

    void Start()
    {
        triggered = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!triggered)
        {
            if (collider.gameObject.layer == 3)
            {
                //print("este checkpoint fue colisionado por el player");
                Trigger();
            }
        }
    }
    void Trigger()
    {
        //print("dispare el metodo Trigger de este checkpoint, mi posicion es " + transform.position);

        if (USBManager.instance != null)
        {
            USBManager.instance.usbsAtCheckpoint = PlayerStats.instance.UsbsCollected; //cuando agarro este checkpoint, le cuento al usbmanager cuantos usbs tengo
        }

        PlayerStats.instance.lastCheckpoint = transform.position;

        particulas.gameObject.SetActive(true);
        AudioManager.instance.PlayPickup(0.5f);

        //print("cambie el lastcheckpoint a " + PlayerStats.instance.lastCheckpoint);

        triggered = true;
    }

    
}