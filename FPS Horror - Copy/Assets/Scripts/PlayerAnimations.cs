using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        if (GetComponent<Animator>() != null)
        {
            anim = GetComponent<Animator>();
        }
    }
    void Update()
    {
	  //if ()
        //anim.SetBool("Walk", true);
        //if ()
        //anim.SetBool("Walk", false);
    }
}
