using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    // este script se lo pones a un objeto para que levite como en gravedad zero
    //el truco es hacer que vaya para arriba lento y girando
    //se lo aplica a sus hijos solamente.
    //por diego katabian

    public Vector3 desiredGrav;

    private Rigidbody[] allRBs;
    void Start()
    {
        allRBs = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allRBs.Length; i++)
        {
            allRBs[i].useGravity = false;
            allRBs[i].AddForce(desiredGrav, ForceMode.Force);
        }


    }
}
