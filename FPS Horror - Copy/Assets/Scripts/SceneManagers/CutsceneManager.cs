using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera camera2;

    public AudioSource darkCircles;
    public float darkCirclesStartingTime;

    [Tooltip("Que tan largo queres el fadeout en ms aprox")]
    public float alarmaFadeOutDuration;

    [Tooltip("Que tanto queres que tarde en moverse la camara, en ms aprox")]
    public float cameraTravelDuration;

    [Tooltip("Que tan largo queres el fadeout en ms aprox")]
    public float textFadeDuration;

    public float timeUntilTexts;
    public float timeBetweenTexts;
    public Canvas creditsCanvas;

    public float timeUntilExplosion;
    public float timeBetweenExplosions;
    public GameObject[] explosions;

    public PlayerMovement pm;

    Text[] _texts;
    float _alarmaTimer;
    float _cameraTimer;

    [HideInInspector]
    public int textToFadeIn;

    [HideInInspector]
    public int textToFadeOut;

    [HideInInspector]
    public bool fadeInGo;

    [HideInInspector]
    public bool fadeOutGo;


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

        AudioManager.instance.PlayAtMoment(darkCircles, darkCirclesStartingTime);

        _texts = creditsCanvas.gameObject.GetComponentsInChildren<Text>();
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].color = new Color(_texts[i].color.r, _texts[i].color.g, _texts[i].color.b, 0); //hago transparentes a todos
        }

        _alarmaTimer = 0;
        _cameraTimer = 0;
        Invoke("StartFadeIn", timeUntilTexts);

        StartCoroutine(PlayExplosions());
    }

    void Update()
    {
        _alarmaTimer += (Time.deltaTime / alarmaFadeOutDuration);
        _cameraTimer += (Time.deltaTime / cameraTravelDuration);

        if (AudioManager.instance.alarmaTriple.isPlaying)
        {
            AudioManager.instance.alarmaTriple.volume = Mathf.Lerp(AudioManager.instance.alarmaTriple.volume, 0, _alarmaTimer);
        }

        pm.MoveForward();

        if (fadeInGo)
        {
            StartCoroutine(FadeTextToFullAlpha(textFadeDuration, _texts[textToFadeIn]));
            fadeInGo = false;
        }
        if (fadeOutGo)
        {
            StartCoroutine(FadeTextToZeroAlpha(textFadeDuration, _texts[textToFadeOut]));
            fadeOutGo = false;
        }

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, camera2.transform.position, _cameraTimer);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, camera2.transform.rotation, _cameraTimer);

        if (textToFadeIn > 0 && Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.PlayMainMenuMusic();
            SceneManager.LoadScene("MainMenuScene"); //volves al main menu
        }
    }

    public void StartFadeIn()
    {
        fadeInGo = true;
    }

    public IEnumerator PlayExplosions()
    {
        yield return new WaitForSeconds(timeUntilExplosion);

        for (int i = 0; i < explosions.Length; i++)
        {
            AudioManager.instance.PlayDerrumbe(i);
            explosions[i].SetActive(true);
            print("cutscene: prendo la explosion " + i);
            yield return new WaitForSeconds(timeBetweenExplosions);
        }
    }

    public IEnumerator FadeTextToFullAlpha(float time, Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
            yield return null;
        }

        yield return new WaitForSeconds(timeBetweenTexts+1);
        fadeOutGo = true;
    }

    public IEnumerator FadeTextToZeroAlpha(float time, Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }

        yield return new WaitForSeconds(timeBetweenTexts);

        if (textToFadeIn < (_texts.Length - 1))
        {
            textToFadeIn++;
            textToFadeOut++;
            fadeInGo = true;
        }
    }

}
