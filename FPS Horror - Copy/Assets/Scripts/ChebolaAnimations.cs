using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChebolaAnimations : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private float _initialSpeed;
    private float _attackRange; //que tan cerca te ataca


    private AnimatorStateInfo stateInfo;
    private bool screamIsReady;

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
        _attackRange = 3f;
        screamIsReady = true;
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("chebola_scream"))
        {
            if (screamIsReady)
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


    }

    void Scream()
    {
        AudioManager.instance.PlayHollowRoar(transform.position, 0);
    }
}
