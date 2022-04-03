using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    public static InvertGravity instance;
    public Rigidbody rb;
    public Vector3 upGrav;
    public Vector3 inverseGrav;
    public float gravityIntensity;
    public bool isGrav;
    void Start()
    {
        instance = this;

        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.useGravity = true;
        upGrav = new Vector3(0, gravityIntensity, 0);
        inverseGrav = Vector3.zero;
        isGrav = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) //swapea la gravedad
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

    public void ToggleGrav() //hace lo mismo que tocar G
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
