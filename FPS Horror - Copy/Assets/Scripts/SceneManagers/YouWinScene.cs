using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class YouWinScene : MonoBehaviour
{
    public Text youWin;
    public Text pressAnyKey;
    private float timer;
    private float timer2;

    public float timeUntilFadeIn;
    public float oscillationFrequency;
    public float transparencyOffset;

    void Start()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.PlayMainMenuMusic();

        youWin.color = new Color(0, 1, 0, 0);
        pressAnyKey.color = new Color(0.5f, 1, 0.5f, 0);

    }

    void Update()
    {
        timer += 0.15f * Time.deltaTime; //timer del youwin
        timer2 += Time.deltaTime; //timer del press e to continue

        youWin.color = new Color(0, 1, 0, Mathf.Lerp(0, 1, timer)); 

        if (timer2 > timeUntilFadeIn) //a los tantos segs aparece oscilando
        {
            pressAnyKey.color = new Color(0.5f, 1, 0.5f, Mathf.Sin(oscillationFrequency * Time.time)+transparencyOffset);
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (timer2 > 4)
            {
                SceneManager.LoadScene(0); //volves al main menu
            }
        }
    }
}