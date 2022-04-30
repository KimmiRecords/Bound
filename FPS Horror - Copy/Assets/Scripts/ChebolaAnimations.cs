using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChebolaAnimations : MonoBehaviour
{

    //este script controla las animaciones del chebola
    //por valen y dk

    private Animator anim;
    private NavMeshAgent agent;

    private float _initialSpeed;
    private float _attackRange; //que tan cerca te ataca
    private bool screamIsReady;
    //private Vector3 _vectorToPlayer;


    void Start()
    {
        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (GetComponent<Animator>() != null)
        {
            anim = GetComponent<Animator>();
        }

        _initialSpeed = agent.speed;
        _attackRange = 5f;
        screamIsReady = true;
        //_vectorToPlayer = transform.position - PlayerStats.playerTransform.position;

    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("chebola_scream"))
        {
            if (screamIsReady) //para que reproduzca el audio una sola vez
            {
                Scream();
                screamIsReady = false;
            }
        }

        //solo tiene velocidad cuando camina
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("chebola_walk"))
        {
            agent.speed = _initialSpeed;
        }
        else
        {
            agent.speed = 0f;
        }


        //si estas bien cerca, arranca la anim de ataque
        if (agent.remainingDistance < _attackRange)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        //print(agent.remainingDistance);
    }

    void Scream()
    {
        AudioManager.instance.PlayHollowRoar(transform.position, 0);
    }
}
