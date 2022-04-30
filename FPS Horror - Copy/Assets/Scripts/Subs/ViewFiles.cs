using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewFiles : MonoBehaviour
{

    //este script se lo agregas a una pc para que te muestre los text files de los usb recolectados.
    //por dk

    public GameObject canvasViewFiles; //el canvas que contiene todos los files

    private Text[] files; 
    private Interactable pc; //yo
    private MouseLook mouseLook; //el unico mouseLook del juego, que esta en el player

    void Start()
    {
        files = canvasViewFiles.GetComponentsInChildren<Text>(); //lleno el array. todos los text files son hijos de ese canvas

        if (FindObjectOfType<MouseLook>() != null)
        {
            mouseLook = FindObjectOfType<MouseLook>();
        }

        if (GetComponent<Interactable>() != null)
        {
            pc = GetComponent<Interactable>();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R) && mouseLook.sensedObj == pc)
        {
            switch(PlayerStats.usbsCollected) //para cada caso, muestro el canvas + los files conseguidos
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
        }
        else  //apago todo
        {
            canvasViewFiles.SetActive(false);
            for (int i = 0; i < files.Length; i++)
            {
                files[i].gameObject.SetActive(false);
            }
        }
    }
}
