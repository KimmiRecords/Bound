using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightLife : MonoBehaviour
{


    public bool start = false;
    public float startTime = 1f;
    public Text textTimer;
    public float timer = 300;
    public GameObject basicFlashlight;


    public void Subtract(int amount)
    {
        if (!start && timer > 0)
        {
            timer -= amount;
            textTimer.text = "Vida util: " + timer.ToString("f0");
            StartCoroutine(PerSecond());
            if (timer == 0)
            {
                basicFlashlight.SetActive(false);
            }

        }

    }

    IEnumerator PerSecond() //lo uso para que cuente cada segundo en que enemi y player collisionan, si no está cuenta cada frame. 
    {
        start = true;
        yield return new WaitForSeconds(startTime);
        start = false;

    }
}
