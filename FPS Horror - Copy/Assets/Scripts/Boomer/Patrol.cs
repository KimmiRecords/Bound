using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour, IRalentizable
{
    //este script se lo adjuntas a un mosntruo para que patrulle
    //va del punto 0 al 1 (pingpong)
    //si el player entra en rango, va hacia el punto 2 y explota a mitad de camino
    //por diego katabian y francisco serra

    public NavMeshAgent miNavMeshAgent;
    public DetectPlayer detectPlayer;
    public Animator miAnimator;
    public Transform[] points;
    public float runningSpeed;
    public float timeUntilExplosionMin;
    public float timeUntilExplosionMax;

    public GameObject exp;

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
        index = 1;
        miNavMeshAgent.destination = points[1].position;
        _yaViAlPlayer = false;
        _timeUntilExplosionPosta = Random.Range(timeUntilExplosionMin, timeUntilExplosionMax);
        AudioManager.instance.PlayZIdle();
    }

    void Update()
    {
        _boomerSounds.UpdateSoundsPosition();

        if (miNavMeshAgent.remainingDistance < 1 && index != 2)
        {
            //index = (index + 1) % points.Length;
            index = 1 - index;
            GoToPoint(   points[index]   );
        }

        if (miNavMeshAgent.remainingDistance < 1 && index == 2)
        {
            miNavMeshAgent.speed = 0;
        }

        if (!_yaViAlPlayer && detectPlayer.playerIsInRange)
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
        GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
        Destroy(_exp, 3);

        if (detectPlayer.playerIsInRange)
        {
            PlayerStats.instance.TakeDamage(PlayerStats.instance.playerHpMax);
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
