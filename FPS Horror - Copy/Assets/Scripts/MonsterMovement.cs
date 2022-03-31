using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public static MonsterMovement instance;

    public float timer;
    public Transform playerTransform;
    public Vector3 playerPosition;
    public Vector3 vectorToPlayer;
    public float distanceToPlayer;
    public float angle; //angulo entre el player y el chebola

    private bool screamerReady = true;
    private bool bgmReady = false;

    public bool enEscena = false; //si esta el chebola en vista o no
    public bool mustStay = true; //si el chebola debe quedarse en su lugar
    

    public float damageAura; //el radio del aura
    public static float monsterSpeed = 0.25f;

    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        mustStay = true;
    }

    void Update()
    {
        playerPosition = playerTransform.position; //actualiza la posicion del jugador

        vectorToPlayer = playerPosition - transform.position; // calculo vector, distancia y angulo al player
        distanceToPlayer = vectorToPlayer.magnitude;
        transform.rotation = Quaternion.LookRotation(vectorToPlayer); //que el chebola siempre apunte al player
        angle = Quaternion.Angle(transform.rotation, playerTransform.rotation);


        //COMANDOS PARA TESTEAR BOLUDECES
        if (Input.GetKeyDown(KeyCode.P)) //toco P para tpear al monstruo behind you
        {
            TPBehindYou(damageAura);
        }

        if (Input.GetKeyDown(KeyCode.O)) //toco O para tpear al monstruo a la loma del pato
        {
            TPFarAway();
        }

        //SEGUIR AL PLAYER
        if (distanceToPlayer <= damageAura && distanceToPlayer > 0.5f)
        {
            transform.position += vectorToPlayer * monsterSpeed * Time.deltaTime;
            PlayerStats.playerHp -= 0.1f; //daña al player constantemente (como un aura de daño)
        }

        //LOGICA DE DESAPARICION DEL MONSTRUO
        if (angle > 90 && distanceToPlayer <= damageAura) //si estoy mirando al chebola y estoy cerca, lo considero en escena y ya queda liberado para tpearse cuando deje de verlo
        {
            enEscena = true;
            mustStay = false;
            if (screamerReady)
            {
                AudioManager.instance.PlayScreamer1();
                AudioManager.instance.StopBGM();
                screamerReady = false;
                bgmReady = true;
            }
        }

        if (angle < 90 && distanceToPlayer > damageAura) //si no lo miro y me alejo lo suficiente, se debe rajar
        {
            enEscena = false;
        }

        if (enEscena == false && mustStay == false) //cuando dejo de mirarlo se tpea lejos
        {
            TPFarAway();
            screamerReady = true;
            if (bgmReady)
            {
                AudioManager.instance.FadeOutScreamer1(10);
                AudioManager.instance.PlayBGM();
                bgmReady = false;
            }
        }
    }

    void TPBehindYou(float distance)
    {
        mustStay = true;                                                             //le pido que se quede aunque no lo vea
        transform.position = playerPosition + (playerTransform.forward * -distance); //teleports behind you
    }

    public void TPToPosition(Vector3 position)
    {
        mustStay = true;               //le pido que se quede aunque no lo vea
        transform.position = position; //teleports a la posicion pedida
    }

    public void TPFarAway()
    {
        transform.position = new Vector3(0, 1000, 0);
    }
}
