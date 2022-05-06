using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float vidita;
    public float hpRegen;

    public static Transform playerTransform;
    
    private static float _playerHp;

    public static float PlayerHp
    {
        get
        {
            return _playerHp;
        }

        set
        {
            _playerHp = value;
        }
    }

    private static int _usbsCollected;
    public static int UsbsCollected
    {
        get
        {
            return _usbsCollected;
        }

        set
        {
            _usbsCollected = value;
            if (_usbsCollected == 4)
            {
                print("YOU WIN");
                _usbsCollected = 0;
                SceneManager.LoadScene(3);
            }
        }
    }


    public static float playerHpMax;
    public static bool agency = true;
    public static bool playerFear = false;

    public static bool boundToggleFlag = false;
    public static bool hasFlashlight = false;

    public GameObject CanvasVidaUtil;
    public GameObject ModeloLinterna;

    private bool gotFlashlightFlag;
    

    void Awake()
    {
        playerHpMax = vidita;
        _playerHp = playerHpMax;
        hasFlashlight = false;
        gotFlashlightFlag = false;
        playerTransform = transform;
    }

    void Update()
    {
        //if (_usbsCollected == 4)
        //{
        //    print("YOU WIN");
        //    _usbsCollected = 0;
        //    SceneManager.LoadScene(3);
        //}

        if (_playerHp < playerHpMax) //regenera hp de a poco
        {
            if (!playerFear) //pero solo si no me esta dañando el chebola
            {
                _playerHp += hpRegen;
            }

            if (_playerHp > playerHpMax) //maxea la vida por si me paso
            {
                _playerHp = playerHpMax;
            }
        }

        if (hasFlashlight && gotFlashlightFlag == false) //asi sucede una sola vez y no todo el tiempo
        {
            CanvasVidaUtil.SetActive(true);
            ModeloLinterna.SetActive(true);
            gotFlashlightFlag = true;
        }
    }

    public static void TakeDamage(float dmg)
    {
        PlayerHp -= dmg;
        if (_playerHp <= 0)
        {
            print("YOU DIED");
            SceneManager.LoadScene(2);
        }
    }
}
