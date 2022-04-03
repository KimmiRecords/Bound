using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static float playerHp;
    public static float playerHpMax;
    public static bool agency = true;
    public static int usbsCollected;

    void Start()
    {
        playerHpMax = 150;
        playerHp = playerHpMax;

    }

    void Update()
    {
        if (playerHp <= 0)
        {
            print("YOU DIED");
            SceneManager.LoadScene(1);
        }

        if (usbsCollected == 4)
        {
            print("YOU WIN");
            usbsCollected = 0;
            SceneManager.LoadScene(2);
        }

        if (playerHp < playerHpMax) //regenera hp de a poco
        {
            playerHp += 0.04f;
        }
        //print("HP Actual = " + playerHp);
    }
}
