using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Instructions : MonoBehaviour
{
    public Text controls;
    public Text objectiveWhite;
    public Text objectiveRed;
    public Text credits;

    public Transform MainCamera;
    public Transform Camera2;

    private Color controlsInitialColor;
    private Color objectiveRedInitialColor;
    private Color creditsInitialColor;

    private bool instructionsSeen = false;
    private float timer;
    public float canvasTimerSpeed;
    private float cameraTimer;
    public float cameraTimerSpeed;


    void Start()
    {
        timer = 0;

        controlsInitialColor = controls.color; //guardo el color inicial
        objectiveRedInitialColor = objectiveRed.color;
        creditsInitialColor = credits.color;

        controls.color = Color.clear; //arrancan invisibles
        objectiveRed.color = Color.clear;
        objectiveWhite.color = Color.clear;
        credits.color = Color.clear;
    }

    void Update()
    {
        timer += (Time.deltaTime / canvasTimerSpeed);
        cameraTimer += (Time.deltaTime / cameraTimerSpeed);


        //MOVIMIENTO CINEMATICO DE LA CAMARA
        //HAGO QUE VAYA DESDE LA POSICION Y ROTACION INICIAL HASTA LAS NUEVAS

        ////lerpeo la posicion de la maincamera, desde su posicion inicial hasta la de la camera2
        //MainCamera.position = new Vector3(Mathf.Lerp(MainCamera.position.x, Camera2.position.x, cameraTimer),
        //                                   Mathf.Lerp(MainCamera.position.y, Camera2.position.y, cameraTimer),
        //                                   Mathf.Lerp(MainCamera.position.z, Camera2.position.z, cameraTimer));


        ////misma pero para la rotacion, sin embargo...
        ////parece que funciona, pero hace que la camara se vuelva loca y gire como trompo.
        ////queda muy copado y lo voy a dejar
        //MainCamera.rotation = Quaternion.Euler(Mathf.Lerp(MainCamera.rotation.eulerAngles.z, Camera2.rotation.eulerAngles.z, cameraTimer),
        //                                       Mathf.Lerp(MainCamera.rotation.eulerAngles.y, Camera2.rotation.eulerAngles.y, cameraTimer),
        //                                       Mathf.Lerp(MainCamera.rotation.eulerAngles.x, Camera2.rotation.eulerAngles.x, cameraTimer));


        MainCamera.position = Vector3.Lerp(MainCamera.position, Camera2.position, cameraTimer);
        MainCamera.rotation = Quaternion.Lerp(MainCamera.rotation, Camera2.rotation, cameraTimer); //jajajaj tan facil




        //LOGICA DEL CANVAS
        if (!instructionsSeen) //fadein de los creditos
        {
            credits.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, timer));
        }

        if (Input.anyKey && instructionsSeen == false) //paso a mostrar las instrucciones
        {
            instructionsSeen = true;
            timer = 0; //reseteo el timer para fadear las instrucciones tambien
        }

        if (instructionsSeen) //fadein de las instrucciones
        {
            credits.color = Color.clear; //apaga los credits

            controls.color = new Color(controlsInitialColor.r, controlsInitialColor.g, controlsInitialColor.b, Mathf.Lerp(0, 1, timer)); //y muestra las instrus
            objectiveRed.color = new Color(objectiveRedInitialColor.r, objectiveRedInitialColor.g, objectiveRedInitialColor.b, Mathf.Lerp(0, 1, timer-0.5f));
            objectiveWhite.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, timer-0.5f));
        }

        //CAMBIO DE ESCENA
        if (Input.GetKeyDown(KeyCode.E) && instructionsSeen == true)
        {
            AudioManager.instance.StopMainMenuMusic();
            AudioManager.instance.PlayBGM();
            SceneManager.LoadScene(0); //0 es el primer nivel
        }
    }
}
