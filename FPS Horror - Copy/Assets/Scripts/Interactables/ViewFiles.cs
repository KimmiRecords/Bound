using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewFiles : Interactable
{

    //este script se lo agregas a una pc para que te muestre los text files de los usb recolectados.
    //por dk

    public GameObject canvasViewFiles; //el canvas que contiene todos los files
    public MouseLook mouseLook; 

    Text[] files; 
    Interactable pc; //yo
    bool isShowing;

    void Awake()
    {
        files = canvasViewFiles.GetComponentsInChildren<Text>(); //lleno el array. todos los text files son hijos de ese canvas
    }

    void Start()
    {
        
        isShowing = false;

        for (int i = 0; i < files.Length; i++)
        {
            files[i].gameObject.SetActive(false); //para empezar, pone a todos en false
        }

        if (mouseLook == null)
        {
            mouseLook = FindObjectOfType<MouseLook>(); //encuentro al mouselook si me olvide de cargarlo en inspector
        }

        if (GetComponent<Interactable>() != null)
        {
            pc = GetComponent<Interactable>(); //encuentro el script interactable de esta pc (en realidad va a encontrar ViewFiles, que hereda de interactable)
        }
    }

    private void Update()
    {
        if (isShowing && mouseLook.sensedObj == null) //para que apague lo mostrado por la pc cuando la dejo de mirar
        {
            canvasViewFiles.SetActive(false);
            for (int i = 0; i < files.Length; i++)
            {
                files[i].gameObject.SetActive(false);
            }
            isShowing = false;
        }
    }

    public override void Interact()
    {
        base.Interact();

        if (!isShowing)
        {
            canvasViewFiles.SetActive(true); //prende el canvas

            if (PlayerStats.instance.UsbsCollected != 0)
            {
                for (int i = 0; i < PlayerStats.instance.UsbsCollected; i++) //prende los textos que tenga
                {
                    files[i].gameObject.SetActive(true);
                }
            }
            isShowing = true;
        }
        else
        {
            canvasViewFiles.SetActive(false);
            for (int i = 0; i < files.Length; i++)
            {
                files[i].gameObject.SetActive(false);
            }
            isShowing = false;
        }
    }
}