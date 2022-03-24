using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float playerHp = 50;
    public static bool agency = false;
    public static int usbsCollected;
    void Start()
    {

    }

    void Update()
    {
        if (playerHp <= 0)
        {
            //print("YOU DIED");
            //ir a pantalla de muerte
        }

        if (usbsCollected == 4)
        {
            print("YOU WIN");
            //ir a pantalla de victoria
        }
    }
}
