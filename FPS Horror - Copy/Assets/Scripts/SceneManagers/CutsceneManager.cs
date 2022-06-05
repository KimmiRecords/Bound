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

    public float timeUntilExplosion;
    public float timeBetweenExplosions;

    public float timeUntilTexts;
    public float timeBetweenTexts;

    public Canvas creditsCanvas;
    Text[] texts;

    public PlayerMovement pm;
    Vector3 _move;


    float _alarmaTimer;
    float _cameraTimer;
    float _textTimer;

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

        texts = creditsCanvas.gameObject.GetComponentsInChildren<Text>();
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].color = new Color(texts[i].color.r, texts[i].color.g, texts[i].color.b, 0); //hago transparentes a todos
        }

        _alarmaTimer = 0;
        _cameraTimer = 0;
        _textTimer = 0;
        Invoke("StartFadeIn", timeUntilTexts);

        StartCoroutine(PlayExplosions());
    }

    void Update()
    {
        _alarmaTimer += (Time.deltaTime / alarmaFadeOutDuration);
        _cameraTimer += (Time.deltaTime / cameraTravelDuration);
        _textTimer += (Time.deltaTime / textFadeDuration);

        if (AudioManager.instance.alarmaTriple.isPlaying)
        {
            AudioManager.instance.alarmaTriple.volume = Mathf.Lerp(AudioManager.instance.alarmaTriple.volume, 0, _alarmaTimer);
        }

        pm.MoveForward();

        if (fadeInGo)
        {
            StartCoroutine(FadeTextToFullAlpha(textFadeDuration, texts[textToFadeIn]));
            fadeInGo = false;
        }
        if (fadeOutGo)
        {
            StartCoroutine(FadeTextToZeroAlpha(textFadeDuration, texts[textToFadeOut]));
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

        for (int i = 0; i < 3; i++)
        {
            AudioManager.instance.PlayDerrumbe(i);
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

        if (textToFadeIn < (texts.Length - 1))
        {
            textToFadeIn++;
            textToFadeOut++;
            fadeInGo = true;
        }
    }

}
