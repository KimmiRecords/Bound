using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlateAudioTrigger : AudioTriggers
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) //la 7 es las graviboxes
        {
            TriggerAndDestroy();
        }
    }
}
