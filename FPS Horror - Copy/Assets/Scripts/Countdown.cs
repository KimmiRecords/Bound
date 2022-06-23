using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float countdown;
    public float stayBlackTime;
    public Text countdownText;
    public Image black;
    public GameObject allCountdownTexts;
    public FinalUSB finalUsb;
    public PlayerStats playerStats;

    float initialCountdownTime;
    float minutes;
    float seconds;
    float milliSeconds;
    bool countdownIsRunning;

    bool todoMalStart;

    void Start()
    {
        initialCountdownTime = countdown;
        countdownIsRunning = false;
        todoMalStart = false;
        finalUsb.OnFinalUSBPickup += InitializeCountdown;
        playerStats.OnDeath += ResetCountdown;
    }

    void Update()
    {
        if (countdownIsRunning)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                countdown = 0;
                countdownIsRunning = false;
                StartCoroutine("StayBlack");
            }
        }

        if (!todoMalStart)
        {
            if (Mathf.Floor(countdown) == 0)
            {
                todoMalStart = true;
                InitializeTodoMal();
            }
        }

        DisplayTime(countdown);
    }

    void InitializeCountdown()
    {
        countdownIsRunning = true;
        allCountdownTexts.SetActive(true);
    }

    void InitializeTodoMal()
    {
        print("initialize todo mal");
        black.color = new Color(0, 0, 0, 1);
        AudioManager.instance.PlayDerrumbe(0);
    }

    void CountdownEnd()
    {
        print("countdown end");
        countdown = 0;

        AudioManager.instance.PlayDerrumbe(2);
        //ResetCountdown(transform.position);
        playerStats.InstaDeath();
    }

    IEnumerator StayBlack()
    {
        print("arranca el stayblack");
        countdown = 0;

        yield return new WaitForSeconds(stayBlackTime);
        CountdownEnd();
    }

    void ResetCountdown(Vector3 cp)
    {
        print("reset countdown");
        todoMalStart = false;
        black.color = new Color(0, 0, 0, 0);
        countdownIsRunning = true;
        countdown = initialCountdownTime;
    }

    void DisplayTime(float t)
    {
        minutes = Mathf.FloorToInt(t / 60);
        seconds = Mathf.FloorToInt(t % 60);
        milliSeconds = (t % 1) * 1000;
        countdownText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
