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

    public float runningSpeed;
    public float timeUntilExplosionMin;
    public float timeUntilExplosionMax;

    public Transform[] points;

    [HideInInspector]
    public int index;

    BoomerAnimations boomerAnims;
    float timeUntilExplosionPosta;
    float _speedModifier;
    bool yaViAlPlayer;

    void Start()
    {
        index = 1;
        miNavMeshAgent.destination = points[1].position;
        yaViAlPlayer = false;

        timeUntilExplosionPosta = Random.Range(timeUntilExplosionMin, timeUntilExplosionMax);
        boomerAnims = new BoomerAnimations(miAnimator);

    }

    void Update()
    {
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

        if (!yaViAlPlayer && detectPlayer.playerIsInRange)
        {
            boomerAnims.StartRunning();
            miNavMeshAgent.speed = runningSpeed * _speedModifier;
            index = 2;
            GoToPoint(points[index]);
            Invoke("Stop", timeUntilExplosionPosta - 2);
            Invoke("Explode", timeUntilExplosionPosta);

            yaViAlPlayer = true;
        }
    }

    public void GoToPoint(Transform point)
    {
        miNavMeshAgent.destination = point.position;
    }

    public void Explode()
    {
        print("explote");

        if (detectPlayer.playerIsInRange)
        {
            PlayerStats.instance.TakeDamage(PlayerStats.instance.playerHpMax);
        }

        this.gameObject.SetActive(false);
    }

    public void Stop()
    {
        boomerAnims.StartPain();
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
