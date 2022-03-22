using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelector : MonoBehaviour
{
    public GameObject mainmenu;
    public Camera playerCamera;
    public Camera menuCamera;
    public bool isMainmenu; //si estamo en el main menu
    public Vector3 mainMenuPoint;

    void Start()
    {
        isMainmenu = true;

        playerCamera.enabled = false;
        menuCamera.enabled = true;
    }

    void Update()
    {
        if (isMainmenu)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
            {
                mainmenu.SetActive(false);
                PlayerStats.agency = true;
                isMainmenu = false;
                playerCamera.enabled = true;
                menuCamera.enabled = false;

            }

        }
    }
}
