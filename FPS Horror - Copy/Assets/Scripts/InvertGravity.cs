using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 upGrav;
    public Vector3 inverseGrav;
    public float gravityIntensity;
    public bool isGrav;
    void Start()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.useGravity = true;
        upGrav = new Vector3(0, gravityIntensity, 0);
        inverseGrav = Vector3.zero;
        isGrav = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isGrav)
            {
                rb.useGravity = false;
                inverseGrav = upGrav;
                isGrav = false;
            }
            else
            {
                rb.useGravity = true;
                inverseGrav = Vector3.zero;
                isGrav = true;
            }


        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(inverseGrav, ForceMode.Force); //aplica inverseGrav constantemente
    }
}
