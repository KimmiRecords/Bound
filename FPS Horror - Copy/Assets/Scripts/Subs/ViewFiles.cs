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

    private Text[] files; 
    private Interactable pc; //yo
    private bool isShowing;


    private void Awake()
    {
        files = canvasViewFiles.GetComponentsInChildren<Text>(); //lleno el array. todos los text files son hijos de ese canvas
    }

    void Start()
    {
        
        isShowing = false;

        for (int i = 0; i < files.Length; i++)
        {
            files[i].gameObject.SetActive(false);
        }

        if (mouseLook == null)
        {
            mouseLook = FindObjectOfType<MouseLook>();
        }

        if (GetComponent<Interactable>() != null)
        {
            pc = GetComponent<Interactable>();
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
            switch (PlayerStats.UsbsCollected) //para cada caso, muestro el canvas + los files conseguidos
            {
                case 0:
                    canvasViewFiles.SetActive(true);
                    break;

                case 1:
                    canvasViewFiles.SetActive(true);
                    files[0].gameObject.SetActive(true);
                    break;

                case 2:
                    canvasViewFiles.SetActive(true);
                    files[0].gameObject.SetActive(true);
                    files[1].gameObject.SetActive(true);
                    break;

                case 3:
                    canvasViewFiles.SetActive(true);
                    files[0].gameObject.SetActive(true);
                    files[1].gameObject.SetActive(true);
                    files[2].gameObject.SetActive(true);
                    break;

                case 4:
                    canvasViewFiles.SetActive(true);
                    files[0].gameObject.SetActive(true);
                    files[1].gameObject.SetActive(true);
                    files[2].gameObject.SetActive(true);
                    files[3].gameObject.SetActive(true);
                    break;
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