using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterMovement : MonoBehaviour, IRalentizable
{
    //este script se lo adjuntas al chebola para que haga daño en aura al player, y lo persiga si es visto
    //por diego katabian y valentino roman

    public float damageAura; //el radio del aura
    public float monsterDamage; // el daño que hace
    public GameObject chebolaPrefab;
    public int desiredScreamer; //si voy a pedir el screamer 1 o 2 o cual

    Transform _playerTransform;
    Vector3 _playerPosition;
    Vector3 _vectorToPlayer;
    Vector3 _initialPosition;
    float _distanceToPlayer;
    float _angle; //angulo entre el player y el chebola
    bool _screamerReady = true; //si el screamer ta ready para salir
    bool _bgmReady = false; //si la musiquita ...
    bool _enEscena = false; //si esta el chebola en vista o no
    bool _mustStay = true; //si el chebola debe quedarse en su lugar. lo uso por si te tiene que esperar aunque no lo veas.
    public Animator _anim;
    public NavMeshAgent _agent;
    protected ChebolaAnimations _chebolaAnims;
    bool habilitado;

    float _initialSpeed;

    [HideInInspector]
    public float finalSpeed;

    void Start()
    {
        if (GetComponent<NavMeshAgent>() != null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        if (GetComponent<Animator>() != null)
        {
            _anim = GetComponent<Animator>();
        }

        finalSpeed = _agent.speed;
        _initialPosition = transform.position;
        _initialSpeed = _agent.speed;
        _playerTransform = PlayerStats.instance.playerTransform;
        _mustStay = true;
        PlayerStats.instance.playerFear = false;
        _chebolaAnims = new ChebolaAnimations(this);
        habilitado = true;
    }

    void Update()
    {
        _chebolaAnims.AnimUpdate();

        _playerPosition = _playerTransform.position; //actualiza la posicion del jugador

        _vectorToPlayer = _playerPosition - transform.position; // calculo vector, distancia y angulo al player
        _distanceToPlayer = _vectorToPlayer.magnitude;

        transform.rotation = Quaternion.LookRotation(_vectorToPlayer); //que el chebola siempre apunte al player
        _angle = Quaternion.Angle(Quaternion.LookRotation(_vectorToPlayer), _playerTransform.rotation);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z); //lockeo la rotacion en X. si no cada vez que el player salta, el chebola rota en x.

        _agent.destination = _playerPosition; //se mueve constantemente hacia el player
        _agent.updateRotation = false;


        //EL CHEBOLA TE PERSIGUE Y DAÑA

        if (habilitado)
        {
            SeekAndDestroy();
        }

        //EL CHEBOLA SE VA

        if (_angle < 90 && _distanceToPlayer > damageAura) //si volteas y te alejas, zafas
        {
            _enEscena = false;
        }

        if (_enEscena == false && _mustStay == false) //cuando dejo de mirarlo se destruye
        {
            CalmDown();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3) //layer 3 es Player
        {
            PlayerStats.instance.TakeDamage(PlayerStats.instance.playerHpMax); //me mata de una si me toca
        }
    }

    public void TPBehindYou(float distance)
    {
        _mustStay = true;                                                             //le pido que se quede ahi aunque no lo vea
        transform.position = _playerPosition + (_playerTransform.forward * -distance); //teleports behind you
    }

    public void TPToPosition(Vector3 position)
    {
        _mustStay = true;               //le pido que se quede ahi aunque no lo vea
        transform.position = position; //teleports a la posicion pedida
    }

    public void SeekAndDestroy()
    {
        Ray ray = new Ray(transform.position, _vectorToPlayer); //el rayo va desde mi hasta el player
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * damageAura, Color.red);

        if (Physics.Raycast(ray, out hit, damageAura)) //si el raycast le pega a algo
        {
            if (hit.transform.gameObject.layer != 13) //y ese algo no es una pared o una puerta
            {
                if (hit.transform.gameObject.layer == 3 && _angle > 135) //y ese algo es layer 3 (player) //CHEBOLA ACTIVATE
                {
                    _enEscena = true;
                    _mustStay = false; //ya esta liberado para irse en cuanto el player se aleje lo suficiente
                    _anim.SetBool("isWalking", true);
                    Damage(); //daño constantemente al player mientras me mire

                    if (_screamerReady) //ONEHIT
                    {
                        //me suscribo a OnDeath. asi me reseteo cuando el player muera estando yo activo.
                        print("suscribi ResetChebola al ondeath");
                        PlayerStats.instance.OnDeath += ResetChebola; //ya enterate

                        AudioManager.instance.PlayScreamer(desiredScreamer);

                        AudioManager.instance.StopBGM();
                        _screamerReady = false; //flags para que solo pase una vez
                        _bgmReady = true;
                    }
                }
            }
        }
    }

    public void Damage()
    {
        PlayerStats.instance.TakeDamage(monsterDamage); //daña al player constantemente
        PlayerStats.instance.playerFear = true;
    }

    public void ResetChebola(Vector3 cp)
    {
        print("arranca el metodo ResetChebola");

        print("lo calmo");
        CalmDown();

        print("destruyo al chebola");
        Destroy(this.gameObject);
    }

    public void CalmDown()
    {
        _agent.destination = transform.position; //o sea, a ningun lado
        _anim.SetBool("isWalking", false);
        _screamerReady = true; //los violines
        _chebolaAnims.screamIsReady = true; //el aullido del chebola
        if (_bgmReady)
        {
            print("anulo la suscripcion");
            PlayerStats.instance.OnDeath -= ResetChebola;

            AudioManager.instance.FadeOutScreamer(desiredScreamer, 1);
            AudioManager.instance.PlayHeavyBreathing();

            AudioManager.instance.PlayBGM();
            PlayerStats.instance.playerFear = false;
            _bgmReady = false;
        }
    }

    public void Habilitar()
    {
        habilitado = true;
    }
    public void EnterSlow()
    {
        //_agent.speed *= 0.5f;
        finalSpeed = _agent.speed * 0.5f;
        //print("bajo la speed a " + _agent.speed);
    }

    public void ExitSlow()
    {
        //_agent.speed *= 2;
        finalSpeed = _initialSpeed;
        //print("volvio la speed a " + _agent.speed);

    }
}
