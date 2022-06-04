using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpin : MonoBehaviour
{
    //este script hace rotar eternamente un objeto
    //lo uso para rotar la luz de los usb en las insutrcciones
    //por diego katabian


    public float spin; //recomiendo 0.1f

    public float xdegrees;
    public float ydegrees;
    public float zdegrees;

    public bool FreezeX;
    public bool FreezeY;
    public bool FreezeZ;

    float desiredX;
    float desiredY;
    float desiredZ;

    float spinStep;
    private void Start()
    {
        spinStep = spin;
    }

    void Update()
    {
        spin += spinStep;


        if (FreezeX)
        {
            desiredX = xdegrees;
        }
        else
        {
            desiredX = spin;
        }

        if (FreezeY)
        {
            desiredY = ydegrees;
        }
        else
        {
            desiredY = spin;
        }

        if (FreezeZ)
        {
            desiredZ = zdegrees;
        }
        else
        {
            desiredZ = spin;
        }


        transform.rotation = Quaternion.Euler(desiredX, desiredY, desiredZ);
    }
}
