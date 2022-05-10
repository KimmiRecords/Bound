using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations
{
    //este script es construido por PlayerMovement. maneja las animaciones de idle, caminar, y las 3 de saltar.
    //por valen y dk

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
    
    public void PlayJumping()
    {
        _anim.SetBool("IsJumping", true);
    }

    public void StopJumping()
    {
        _anim.SetBool("IsJumping", false);
    }

    public void PlayFalling()
    {
        _anim.SetBool("IsFalling", true);
    }

    public void StopFalling()
    {
        _anim.SetBool("IsFalling", false);
    }

    public void PlayLanding()
    {
        _anim.SetBool("IsGrounded", true);
    }

    public void StopLanding()
    {
        _anim.SetBool("IsGrounded", false);
    }
}
