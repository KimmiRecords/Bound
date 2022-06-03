using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class YouDiedScene : MonoBehaviour
{
    public Text youDied;
    public Text pressAnyKey;
    private float timer;
    private float timer2;

    public float timeUntilFadeIn;
    public float oscillationFrequency;
    public float transparencyOffset;

    void Start()
    {
        AudioManager.instance.StopBGM();
        AudioManager.instance.StopPasos();


        youDied.color = new Color(1, 0, 0, 0);
        pressAnyKey.color = new Color(1, 0.5f, 0.5f, 0);
    }

    void Update()
    {
        timer += 0.15f * Time.deltaTime;
        timer2 += Time.deltaTime;

        youDied.color = new Color(1, 0, 0, Mathf.Lerp(0,1,timer));

        if (timer2 > timeUntilFadeIn) //a los tantos segs aparece oscilando
        {
            pressAnyKey.color = new Color(1, 0.5f, 0.5f, Mathf.Sin(oscillationFrequency * Time.time)+transparencyOffset);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.PlayMainMenuMusic();

            SceneManager.LoadScene("MainMenuScene"); //volves al main menu
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.instance.StopAll();
            Destroy(AudioManager.instance.gameObject);

            SceneManager.LoadScene("Nivel1"); //volves al nivel
        }

    }
}
