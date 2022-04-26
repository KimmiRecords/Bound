using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChebolaTrigger : MonoBehaviour
{
    //este script se lo adjuntas al chebola.
    //en el inspector, carga cada usb que haya
    //determina cómo triggerea la aparicion del chebola para cada interactable

    private MouseLook mouseLook;

    public Interactable usb0;
    public Interactable usb1;
    public Interactable usb2;
    public Interactable usb3;

    public Vector3 usbTriggerPosition0; //-120,3,49
    public Vector3 usbTriggerPosition1; //-44,7,56
    public Vector3 usbTriggerPosition2; //-30,3,-20
    public Vector3 usbTriggerPosition3; //-43,3,-6


    void Start()
    {
        if (FindObjectOfType<MouseLook>() != null)
        {
            mouseLook = FindObjectOfType<MouseLook>();
        }

    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && mouseLook.sensedObj)
        {
            if (mouseLook.sensedObj == usb0)
            {
                MonsterMovement.instance.TPToPosition(usbTriggerPosition0);
            }

            if (mouseLook.sensedObj == usb1)
            {
                MonsterMovement.instance.TPToPosition(usbTriggerPosition1);
            }

            if (mouseLook.sensedObj == usb2)
            {
                MonsterMovement.instance.TPToPosition(usbTriggerPosition2);
            }

            if (mouseLook.sensedObj == usb3)
            {
                MonsterMovement.instance.TPToPosition(usbTriggerPosition3);
            }
        }
    }
}
