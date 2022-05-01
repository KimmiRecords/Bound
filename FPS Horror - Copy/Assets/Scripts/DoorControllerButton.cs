using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerButton : MonoBehaviour
{
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

    // Update is called once per frame
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
