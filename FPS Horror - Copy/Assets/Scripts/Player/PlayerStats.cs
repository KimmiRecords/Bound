using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float vidita;
    public float hpRegen;
    public GameObject CanvasVidaUtil;
    public GameObject ModeloLinterna;
    
    private bool _gotFlashlightFlag;

    public static Transform playerTransform;
    public static float playerHpMax;
    public static bool agency = true;
    public static bool playerFear = false;
    public static bool boundToggleFlag = false;
    public static bool hasFlashlight = false;

    private static float _playerHp;
    private static int _usbsCollected;



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
    

    void Awake()
    {
        playerHpMax = vidita;
        hasFlashlight = false;
        playerTransform = transform;
        _playerHp = playerHpMax;
        _gotFlashlightFlag = false;
        UsbsCollected = 0;
    }

    void Update()
    {
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

        if (hasFlashlight && _gotFlashlightFlag == false) //asi sucede una sola vez y no todo el tiempo
        {
            CanvasVidaUtil.SetActive(true);
            ModeloLinterna.SetActive(true);
            _gotFlashlightFlag = true;
        }

        print(_playerHp);
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
