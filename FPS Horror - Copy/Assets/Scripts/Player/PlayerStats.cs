using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    //todos los stats del personaje principal
    //incluye getter y setter para hp y usbs recolectados
    //inluye metodos para hacerme daño, y variables para los estados del player (si tiene linterna, llaves, etc)
    //por diego katabian, francisco serra y rocio casco

    public static PlayerStats instance;

    public float playerHpMax;
    public float hpRegen;
    public GameObject CanvasVidaUtil;
    public GameObject ModeloLinterna;

    [HideInInspector]
    public Transform playerTransform;

    [HideInInspector]
    public bool playerFear = false;

    [HideInInspector]
    public bool hasFlashlight = false;

    [HideInInspector]
    public bool hasCardKey = false;

    bool _gotFlashlightFlag;
    float _playerHp;
    int _usbsCollected;

    public float PlayerHp
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

    public int UsbsCollected
    {
        get
        {
            return _usbsCollected;
        }

        set
        {
            _usbsCollected = value;
            //if (_usbsCollected == 4)
            //{
            //    print("YOU WIN");
            //    _usbsCollected = 0;
            //    SceneManager.LoadScene(3);
            //}
        }
    }

    void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

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

        if (Input.GetKeyDown(KeyCode.L))
        {
            UsbsCollected++;
            print("CHEAT: te sumaste un usb");
        }
    }

    public void TakeDamage(float dmg)
    {
        PlayerHp -= dmg;
        if (_playerHp <= 0)
        {
            print("YOU DIED");
            SceneManager.LoadScene("YouDiedScene");
        }
    }

    public void Win()
    {
        print("YOU WIN");
        _usbsCollected = 0;
        SceneManager.LoadScene("YouWinScene");
    }
}
