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

    private Color controlsInitialColor;
    private Color objectiveRedInitialColor;
    private Color creditsInitialColor;

    private bool instructionsSeen = false;
    private float timer;

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
        timer += Time.deltaTime / 5;

        if (!instructionsSeen)
        {
            credits.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, timer));
        }

        if (Input.anyKey && instructionsSeen == false)
        {
            instructionsSeen = true;

            timer = 0;
        }

        if (instructionsSeen)
        {
            credits.color = Color.clear; //apaga los credits

            controls.color = new Color(controlsInitialColor.r, controlsInitialColor.g, controlsInitialColor.b, Mathf.Lerp(0, 1, timer)); //y muestra las instrus
            objectiveRed.color = new Color(objectiveRedInitialColor.r, objectiveRedInitialColor.g, objectiveRedInitialColor.b, Mathf.Lerp(0, 1, timer-1));
            objectiveWhite.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, timer-1));
        }

        if (Input.GetKeyDown(KeyCode.E) && instructionsSeen == true)
        {
            AudioManager.instance.StopMainMenuMusic();
            AudioManager.instance.PlayBGM();
            SceneManager.LoadScene(0);
        }
    }
}
