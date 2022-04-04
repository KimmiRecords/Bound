using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejaPuzzle1 : MonoBehaviour
{
    public static RejaPuzzle1 instance;
    public static bool open;
    public Vector3 traslacion;
    
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        open = false;
    }

    void Update()
    {
        
    }

    public void ToggleReja()
    {
        open = !open; //togglea el estado
        if (open)
        {
            transform.position -= traslacion; //la mueve
        }
        else
        {
            transform.position += traslacion; 
        }
    }
}
