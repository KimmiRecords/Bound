using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterMovement : MonoBehaviour
{

    //este script se lo adjuntas al chebola para que haga daño en aura al player, y lo persiga si es visto -- por dk


    //public static MonsterMovement instance;

    private Transform _playerTransform;

    private Vector3 _playerPosition;
    private Vector3 _vectorToPlayer;
    private Vector3 _farAway;

    private float _distanceToPlayer;
    private float _angle; //angulo entre el player y el chebola

    private bool _screamerReady = true; //si el screamer ta ready para salir
    private bool _bgmReady = false; //si la musiquita ...

    private bool _enEscena = false; //si esta el chebola en vista o no
    private bool _mustStay = true; //si el chebola debe quedarse en su lugar. lo uso por si te tiene que esperar aunque no lo veas.
    

    private float _damageAura; //el radio del aura

    //public Vector3 usbTriggerPosition0;
    //public Vector3 usbTriggerPosition1;
    //public Vector3 usbTriggerPosition2; 
    //public Vector3 usbTriggerPosition3;

    public static float monsterSpeed = 0.25f;

    private NavMeshAgent agent;

    void Start()
    {
        //if (instance)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    instance = this;
        //}

        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        _playerTransform = PlayerStats.playerTransform;
        _damageAura = 18f;
        _farAway = new Vector3(0, 0, 0);
        _mustStay = true;
        PlayerStats.playerFear = false;

    }

    void Update()
    {
        _playerPosition = _playerTransform.position; //actualiza la posicion del jugador

        _vectorToPlayer = _playerPosition - transform.position; // calculo vector, distancia y angulo al player
        _distanceToPlayer = _vectorToPlayer.magnitude;

        transform.rotation = Quaternion.LookRotation(_vectorToPlayer); //que el chebola siempre apunte al player
        _angle = Quaternion.Angle(transform.rotation, _playerTransform.rotation);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z); //lockeo la rotacion en X. si no cada vez que el player salta, el chebola rota en x.

        //COMANDOS PARA TESTEAR
        if (Input.GetKeyDown(KeyCode.P)) //toco P para tpear al monstruo behind you
        {
            TPBehindYou(_damageAura);
        }

        if (Input.GetKeyDown(KeyCode.O)) //toco O para tpear al monstruo a la loma del pato
        {
            TPFarAway();
        }


        //EL CHEBOLA TE PERSIGUE Y DAÑA

        //raycast
        //si estoy viendo al player...
        Ray ray = new Ray(transform.position, _vectorToPlayer);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * _damageAura, Color.red);

        if (Physics.Raycast(ray, out hit, _damageAura)) //si el raycast le pega a algo
        {
            if (hit.transform.gameObject.layer != 13) //y ese algo no es una pared o una puerta
            {
                if (hit.transform.gameObject.layer == 3) //y ese algo es layer 3 (player)
                {
                    print("i see you");
                    if (_distanceToPlayer <= _damageAura) //y estas en rango...
                    {
                        if (_angle > 145) //en cuanto tengas al chebola de frente, me considere en escena y empiezo a hacerte daño
                        {
                            _enEscena = true;
                            _mustStay = false;
                            agent.destination = _playerPosition; //me muevo hacia el player
                                                                 //anim.SetBool("isWalking", true);
                            Damage();

                            if (_screamerReady) //y si el screamer esta listo...
                            {
                                AudioManager.instance.PlayScreamer1(); //arranca el todo mal
                                AudioManager.instance.StopBGM();
                                _screamerReady = false; //flag para que solo pase una vez
                                _bgmReady = true;
                            }
                        }
                    }
                }
            }
        }


        //if (_distanceToPlayer <= _damageAura) //si estas en aura...
        //{
        //    if (_angle > 145) //en cuanto ves al chebola, lo considero en escena y empieza a hacer daño
        //    {
        //        _enEscena = true;
        //        _mustStay = false;
        //        agent.destination = _playerPosition; //me muevo hacia el player
        //        //anim.SetBool("isWalking", true);
        //        Damage();

        //        if (_screamerReady) //y si el screamer esta listo...
        //        {
        //            AudioManager.instance.PlayScreamer1(); //arranca el todo mal
        //            AudioManager.instance.StopBGM();
        //            _screamerReady = false; //flag para que solo pase una vez
        //            _bgmReady = true;
        //        }
        //    }
        //}

        if (_angle < 90 && _distanceToPlayer > _damageAura) //si volteas y te alejas, zafas
        {
            _enEscena = false;
        }

        if (_enEscena == false && _mustStay == false) //cuando dejo de mirarlo se tpea lejos
        {
            //TPFarAway();
            agent.destination = transform.position; //o sea, a ningun lado
            //anim.SetBool("isWalking", false);
            _screamerReady = true;
            if (_bgmReady)
            {
                AudioManager.instance.FadeOutScreamer1(10);
                AudioManager.instance.PlayBGM();
                PlayerStats.playerFear = false;
                _bgmReady = false;
            }
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3) //layer 3 es Player
        {
            PlayerStats.playerHp = 0; //si me toca, me muero
        }
    }

    public void TPBehindYou(float distance)
    {
        _mustStay = true;                                                             //le pido que se quede aunque ahi no lo vea
        transform.position = _playerPosition + (_playerTransform.forward * -distance); //teleports behind you
        print("el chebola aparecio atras tuyo en " + transform.position);
    }

    public void TPToPosition(Vector3 position)
    {
        _mustStay = true;               //le pido que se quede ahi aunque no lo vea
        transform.position = position; //teleports a la posicion pedida
        print("el chebola se tpeo a " + position);
    }

    public void TPFarAway()
    {
        transform.position = _farAway;
        print("El Chebola se tpeo LEJOS");
    }

    public void Damage()
    {
        PlayerStats.playerHp -= 0.1f; //daña al player constantemente
        PlayerStats.playerFear = true;
    }
}
