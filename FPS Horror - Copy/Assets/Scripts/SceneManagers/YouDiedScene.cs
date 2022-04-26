using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class YouDiedScene : MonoBehaviour
{
    public Text youDied;
    public Text pressAnyKey;
    public float timer;
    public float timer2;

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

        youDied.color = new Color(1, 0, 0, Mathf.Lerp(0,1,timer)); //LOS COLORES VAN DE 0 A 1, NO DE 0 A 255 COMO EN EL INSPECTOR. HIJOS DE.

        if (timer2 > 4) //a los 4 segs aparece oscilando
        {
            pressAnyKey.color = new Color(1, 0.5f, 0.5f, Mathf.Sin(1.5f * Time.time));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.StopScreamer1();
            AudioManager.instance.PlayMainMenuMusic();
            SceneManager.LoadScene(0); //volves al main menu
        }

    }
}
