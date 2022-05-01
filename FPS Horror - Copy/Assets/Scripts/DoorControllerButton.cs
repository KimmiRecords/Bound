using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerButton : MonoBehaviour
{
    //este script se lo agregas a una consola para que abra una puerta
    //por fran y dk

    public DoorController quePuertaAbro;

    private MouseLook mouseLook;

    private Interactable yo;


    void Start()
    {
        if (FindObjectOfType<MouseLook>() != null)
        {
            mouseLook = FindObjectOfType<MouseLook>();
        }

        if (GetComponent<Interactable>() != null)
        {
            yo = GetComponent<Interactable>();
        }
    }

    void Update()
    {
        if (mouseLook.sensedObj == yo)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                if (quePuertaAbro._doorAnim.GetBool("isOpening"))
                {
                    quePuertaAbro.CloseDoor();                              
                }
                else
                {
                    quePuertaAbro.OpenDoor();
                }
            }
        }
    }
}
