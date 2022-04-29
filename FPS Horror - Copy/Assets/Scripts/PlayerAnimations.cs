using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations
{
    private Animator _anim;
    private float _moveMag;

    public PlayerAnimations(Animator a)
    {
        _anim = a; //pido el componente por parametro. cuando lo construyan me lo dan.
    }
    
    public void PlayWalking()
    {
        _anim.SetBool("Walk", true);
    }

    public void StopWalking()
    {
        _anim.SetBool("Walk", false);
    }

    public void CheckMagnitude(float moveMag)
    {
        _moveMag = moveMag;
        if (_moveMag != 0)
        {
            PlayWalking(); //si me muevo
        }
        else
        {
            StopWalking(); //si estoy quieto
        }
    }
}
