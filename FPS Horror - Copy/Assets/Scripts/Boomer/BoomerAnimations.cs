using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerAnimations
{
    public Animator anim;
    public BoomerAnimations(Animator a)
    {
        anim = a;
    }
    public void StartRunning()
    {
        //Debug.Log("dispare startrunning");
        anim.SetBool("isRunning", true);
    }

    public void StartPain()
    {
        //Debug.Log("dispare startpain");
        anim.SetBool("isRunning", false);
        anim.SetBool("isPain", true);
    }
}
