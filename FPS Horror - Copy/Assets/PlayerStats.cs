using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float playerHp = 50;
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
