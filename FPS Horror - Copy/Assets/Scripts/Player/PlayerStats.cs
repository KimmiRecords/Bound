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

    public delegate void MyDelegate(Vector3 cp);
    public event MyDelegate OnDeath;

    [HideInInspector]
    public Transform playerTransform;

    [HideInInspector]
    public bool playerFear = false;

    public bool hasFlashlight = false;

    public bool hasCardKey = false;

    [HideInInspector]
    public Vector3 lastCheckpoint;

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
        lastCheckpoint = Vector3.zero;
        _playerHp = playerHpMax;
        _gotFlashlightFlag = false;
        UsbsCollected = 0;
    }

    void Update()
    {
        print(PlayerHp);
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
            print("CHEAT: te sumaste un usb. Ahora tenes " + UsbsCollected);
        }
    }

    public void TakeDamage(float dmg)
    {
        PlayerHp -= dmg;
        if (_playerHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        print("arranca el metodo Die");
        if (lastCheckpoint == Vector3.zero)
        {
            print("YOU DIED");
            SceneManager.LoadScene("YouDiedScene");
        }
        else
        {
            print("hay checkpoint, llamo al evento OnDeath, lastcheckpoint en " + lastCheckpoint);
            PlayerHp = playerHpMax;
            OnDeath(lastCheckpoint);
        }

        //print("YOU DIED");
        //SceneManager.LoadScene("YouDiedScene");
    }

    public void Win()
    {
        print("YOU WIN");
        _usbsCollected = 0;
        SceneManager.LoadScene("YouWinScene");
    }
}
