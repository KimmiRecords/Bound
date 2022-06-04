using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera camera2;

    void Start()
    {
        if (AudioManager.instance.screamer1.isPlaying)
        {
            AudioManager.instance.StopScreamer(1);
        }
        if (AudioManager.instance.screamer2.isPlaying)
        {
            AudioManager.instance.StopScreamer(2);
        }


    }

    void Update()
    {
        //lerp camera1 a camera2

        //yield return waitforseconds(10)
        //StartExplosions();
        //fadeout alarmatriple

        //canvasbound.text.color lerpear a alpha = 1
        //yield return waitforseconds(6)
        //canvasbound.text.color lerpear a alpha = 0
        //a game by tv records
        //tv records is
        //los pibes - roles
        //thanks for playing


    }
}
