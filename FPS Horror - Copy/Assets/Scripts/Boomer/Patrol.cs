using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour, IRalentizable
{
    //este script se lo adjuntas a un mosntruo para que patrulle
    //va del punto 0 al 1 (pingpong)
    //si el player entra en rango, va hacia el punto 2 y explota a mitad de camino
    //TP2 - Francisco Serra y Diego Katabian

    public NavMeshAgent miNavMeshAgent;
    public DetectPlayer detectPlayer;
    public Animator miAnimator;
    public Transform[] points;
    public float runningSpeed;
    public float timeUntilExplosionMin;
    public float timeUntilExplosionMax;

    public GameObject exp;
    public GameObject boomerModel;

    [HideInInspector]
    public int index;

    BoomerAnimations _boomerAnims;
    BoomerSounds _boomerSounds;
    float _timeUntilExplosionPosta;
    float _speedModifier;
    bool _yaViAlPlayer;

    void Start()
    {
        _boomerAnims = new BoomerAnimations(miAnimator);
        _boomerSounds = new BoomerSounds(this);
        index = 0;
        miNavMeshAgent.destination = points[0].position;
        _yaViAlPlayer = false;
        _timeUntilExplosionPosta = Random.Range(timeUntilExplosionMin, timeUntilExplosionMax);
        AudioManager.instance.PlayZIdle();
        _speedModifier = 1;
    }

    void Update()
    {
        _boomerSounds.UpdateSoundsPosition();

        if (miNavMeshAgent.remainingDistance < 1 && index != 2) //si no estoy yendo al punto 2, ciclo entre punto 0 y 1
        {
            //index = (index + 1) % points.Length;
            index = 1 - index;
            GoToPoint(points[index]);
        }


        if (miNavMeshAgent.remainingDistance < 1 && index == 2) //cuando llego al punto 2, me quedo quieto
        {
            miNavMeshAgent.speed = 0;
        }

        if (!_yaViAlPlayer && detectPlayer.playerIsInRange) //veo al player y corro hacia punto 2
        {
            AudioManager.instance.StopZIdle();
            AudioManager.instance.PlayZStress();

            _boomerAnims.StartRunning();
            miNavMeshAgent.speed = runningSpeed * _speedModifier;
            index = 2;
            GoToPoint(points[index]);
            Invoke("Stop", _timeUntilExplosionPosta - 2);
            Invoke("Explode", _timeUntilExplosionPosta);

            _yaViAlPlayer = true;
        }
    }

   

    public void GoToPoint(Transform point)
    {
        miNavMeshAgent.destination = point.position;
    }

    public void Explode()
    {
        AudioManager.instance.StopZScream();
        AudioManager.instance.PlayZExplosion(transform.position);
        GameObject _exp = Instantiate(exp, boomerModel.transform.position, boomerModel.transform.rotation);
        Destroy(_exp, 3);

        if (detectPlayer.playerIsInRange)
        {
            PlayerStats.instance.InstaDeath();
        }

        this.gameObject.SetActive(false);
    }

    public void Stop()
    {
        _boomerAnims.StartPain();
        AudioManager.instance.StopZStress();
        AudioManager.instance.PlayZScream();
        miNavMeshAgent.speed = 0;
    }

    public void EnterSlow()
    {
        _speedModifier = 0.5f;
        miNavMeshAgent.speed *= 0.5f;
    }

    public void ExitSlow()
    {
        _speedModifier = 1;
        miNavMeshAgent.speed *= 2;
    }
}
