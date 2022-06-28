using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightLife : MonoBehaviour
{
    private bool       start = false;
    public  float      startTime = 1f;
    public  float      timer;
    public  Text       textTimer;
    public  GameObject basicFlashlight;

    public void Subtract(int amount)
    {
        if (!start && timer > 0)
        {
            timer -= amount;
            textTimer.text = "Battery life: " + timer.ToString("f0");
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
