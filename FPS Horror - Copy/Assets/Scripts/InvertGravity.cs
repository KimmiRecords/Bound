using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    public static InvertGravity instance;
    public float gravityIntensity;

    private Vector3 upGrav;
    private Vector3 inverseGrav;
    private bool isBound;
    private Rigidbody rb;

    public Interactable soyControladoPor;

    void Start()
    {
        instance = this;

        upGrav = new Vector3(0, gravityIntensity, 0);
        inverseGrav = Vector3.zero;
        isBound = true;

        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.useGravity = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) //swapea la gravedad
        {
            ToggleGrav();
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(inverseGrav, ForceMode.Force); //aplica inverseGrav constantemente
    }

    public void ToggleGrav()
    {
        if (isBound)
        {
            rb.useGravity = false;
            inverseGrav = upGrav;
            isBound = false;
        }
        else
        {
            rb.useGravity = true;
            inverseGrav = Vector3.zero;
            isBound = true;
        }
    }
}
