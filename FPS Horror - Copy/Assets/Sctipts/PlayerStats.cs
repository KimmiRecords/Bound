using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float playerHp = 50;
    public static bool agency = false;
    void Start()
    {

    }

    void Update()
    {
        if (playerHp <= 0)
        {
            //print("YOU DIED");
        }
    }
}
