using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelector : MonoBehaviour
{
    public bool apa = true;
    void Start()
    {
        //todavia 
    }

    void Update()
    {
        //arranca seleccionado Start
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            apa = !apa; //togglea entre selecciones
        }
    }
}
