using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations
{
    private Animator _anim;
    private float _moveMag;

    public PlayerAnimations(Animator a)
    {
        _anim = a;
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
            PlayWalking();
        }
        else
        {
            StopWalking();
        }
        Debug.Log("movemag = " + _moveMag);
    }
}
