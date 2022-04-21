using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float vidita;
    public static float playerHp;
    public static float playerHpMax;
    public static bool agency = true;
    public static int usbsCollected;

    public static bool boundToggleFlag = false;
    public static bool hasFlashlight = false;

    public GameObject CanvasVidaUtil;
    public GameObject ModeloLinterna;

    private bool gotFlashlightFlag;

    void Start()
    {
        playerHpMax = vidita;
        playerHp = playerHpMax;
        hasFlashlight = false;
        gotFlashlightFlag = false;
    }

    void Update()
    {
        if (playerHp > playerHpMax) //maxea la vida por si me paso
        {
            playerHp = playerHpMax;
        }

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
            if (!MonsterMovement.fear) //pero solo si no me esta dañando el chebola
            {
                playerHp += 0.2f;
            }
        }

        if (hasFlashlight && gotFlashlightFlag == false) //asi sucede una sola vez y no todo el tiempo
        {
            CanvasVidaUtil.SetActive(true);
            ModeloLinterna.SetActive(true);
            gotFlashlightFlag = true;
        }
    }
}
