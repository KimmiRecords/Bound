using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulLife : MonoBehaviour
{
    public int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flash light life")
        {
            other.GetComponent<FlashlightLife>().Subtract(amount);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "flash light life")
        {
            other.GetComponent<FlashlightLife>().Subtract(amount);
        }
    }

    //enemy y player estan collisionando (son trigger) llamo al script FlashlightLife para usar su corrutina.
}
