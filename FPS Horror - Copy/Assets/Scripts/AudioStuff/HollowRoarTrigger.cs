using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowRoarTrigger : MonoBehaviour
{
    private Vector3 soundPosition;
    void Start()
    {
        soundPosition = transform.position + new Vector3(10, 0, 0);
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        //print("le di play al hollow roar en" + soundPosition);
        //AudioManager.instance.PlayHollowRoar(soundPosition, 2);
    }
}
