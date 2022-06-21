using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChebolaAnimations
{
    //este script controla las animaciones del chebola
    //por valentino roman y diego katabian

    Animator _anim;
    NavMeshAgent _agent;
    MonsterMovement _mm;
    float _finalSpeed;
    float _attackRange; //que tan cerca te ataca
    public bool screamIsReady;

    public ChebolaAnimations(MonsterMovement mm)
    {
        _anim = mm._anim;
        _agent = mm._agent;
        _mm = mm;

        _attackRange = 5f;
        screamIsReady = true;
    }

    public void AnimUpdate()
    {
        _finalSpeed = _mm.finalSpeed;

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("chebola_scream"))
        {
            if (screamIsReady) //para que reproduzca el audio una sola vez
            {
                Scream();
                screamIsReady = false;
            }
        }

        //solo tiene velocidad cuando camina
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("chebola_walk"))
        {
            _agent.speed = _finalSpeed;
        }
        else
        {
            _agent.speed = 0f;
        }


        //si estas bien cerca, arranca la anim de ataque
        if (_agent.remainingDistance < _attackRange)
        {
            _anim.SetBool("isAttacking", true);
        }
        else
        {
            _anim.SetBool("isAttacking", false);
        }

        //print(agent.remainingDistance);
    }

    void Scream()
    {
        AudioManager.instance.PlayHollowRoar(_agent.gameObject.transform.position, 0, 1.1f);
    }
}
