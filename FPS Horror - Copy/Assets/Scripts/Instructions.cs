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

    private bool instructionsSeen = false;

    void Start()
    {
        controlsInitialColor = controls.color; //guardo el color inicial
        objectiveRedInitialColor = objectiveRed.color;

        controls.color = Color.clear; //arrancan invisibles
        objectiveRed.color = Color.clear;
        objectiveWhite.color = Color.clear;

    }

    void Update()
    {
        if (Input.anyKey)
        {
            credits.color = Color.clear;

            controls.color = controlsInitialColor;
            objectiveRed.color = objectiveRedInitialColor;
            objectiveWhite.color = Color.white;

            instructionsSeen = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && instructionsSeen == true)
        {
            AudioManager.instance.StopMainMenuMusic();
            AudioManager.instance.PlayBGM();
            SceneManager.LoadScene(0);
        }
    }
}
