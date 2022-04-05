using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterMovement : MonoBehaviour
{
    public static MonsterMovement instance;
    public Transform playerTransform;

    private float _timer;
    private Vector3 _playerPosition;
    private Vector3 _vectorToPlayer;
    private float _distanceToPlayer;
    private float _angle; //angulo entre el player y el chebola

    private bool _screamerReady = true;
    private bool _bgmReady = false;

    private bool _enEscena = false; //si esta el chebola en vista o no
    private bool _mustStay = true; //si el chebola debe quedarse en su lugar
    

    public float damageAura; //el radio del aura
    public static float monsterSpeed = 0.25f;

    public NavMeshAgent agent;

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

        _mustStay = true;

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _playerPosition = playerTransform.position; //actualiza la posicion del jugador

        _vectorToPlayer = _playerPosition - transform.position; // calculo vector, distancia y angulo al player
        _distanceToPlayer = _vectorToPlayer.magnitude;


        transform.rotation = Quaternion.LookRotation(_vectorToPlayer); //que el chebola siempre apunte al player
        _angle = Quaternion.Angle(transform.rotation, playerTransform.rotation);


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
        if (_distanceToPlayer <= damageAura && _distanceToPlayer > 0.5f) 
        {
            agent.destination = _playerPosition;
            PlayerStats.playerHp -= 0.1f; //daña al player constantemente (como un aura de daño), lo vea o no
        }

        //LOGICA DE APARICION DEL MONSTRUO
        if (_angle > 90 && _distanceToPlayer <= damageAura) //si estoy mirando al chebola y estoy cerca, lo considero en escena y ya queda liberado para tpearse cuando deje de verlo
        {
            _enEscena = true;
            _mustStay = false;

            if (_screamerReady) //el screamer arranca cuando lo veo y estoy cerca
            {
                AudioManager.instance.PlayScreamer1();
                AudioManager.instance.StopBGM();
                _screamerReady = false;
                _bgmReady = true;
            }
            
        }

        if (_angle < 90 && _distanceToPlayer > damageAura) //si no lo miro y me alejo lo suficiente, se debe rajar
        {
            _enEscena = false;
        }

        if (_enEscena == false && _mustStay == false) //cuando dejo de mirarlo se tpea lejos
        {
            TPFarAway();
            _screamerReady = true;
            if (_bgmReady)
            {
                AudioManager.instance.FadeOutScreamer1(10);
                AudioManager.instance.PlayBGM();
                _bgmReady = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3) //layer 3 es Player
        {
            PlayerStats.playerHp = 0;
        }
        

    }

    public void TPBehindYou(float distance)
    {
        _mustStay = true;                                                             //le pido que se quede aunque ahi no lo vea
        transform.position = _playerPosition + (playerTransform.forward * -distance); //teleports behind you
    }

    public void TPToPosition(Vector3 position)
    {
        _mustStay = true;               //le pido que se quede ahi aunque no lo vea
        transform.position = position; //teleports a la posicion pedida
    }

    public void TPFarAway()
    {
        transform.position = new Vector3(0, 1000, 0);
    }
}
