using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInPlace : MonoBehaviour
{
    //este script se lo pones al padre para que sus hijos floten en el lugar
    //por diego katabian

    public Vector3 desiredGrav;

    Rigidbody[] allRBs;
    float timer;
    Vector3 finalGrav;

    void Start()
    {
        allRBs = GetComponentsInChildren<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        finalGrav.x = Mathf.Sin(timer) * desiredGrav.x;
        finalGrav.y = Mathf.Sin(timer) * desiredGrav.y;
        finalGrav.z = Mathf.Sin(timer) * desiredGrav.z;

        //finalGrav = Mathf.Clamp(finalGrav, 0, 1);

        for (int i = 0; i < allRBs.Length; i++)
        {
            allRBs[i].useGravity = false;
            allRBs[i].AddForce(finalGrav, ForceMode.Force);
        }
    }

}
