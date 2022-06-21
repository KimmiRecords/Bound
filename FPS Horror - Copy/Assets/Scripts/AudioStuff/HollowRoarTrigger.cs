using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowRoarTrigger : MonoBehaviour
{
    //este script se lo adjuntas a un pickup para que cuando lo pickupees (y destruyas) reproduzca un tenebroso audio de chebola en la posicion deseada.
    //por francisco serra y diego katabian

    public Vector3 soundPosition;
    public float delay;

    private void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) //esto es clave. solo va a reproducir si la escena esta activa. asi, si cierro la escena y se destruye todo, no reproduce nada.
        {
            return;
        }
        print("le di play al hollow roar en" + soundPosition);
        AudioManager.instance.PlayHollowRoar(soundPosition, delay, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(soundPosition, 1);
    }
}
