using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerSounds
{
    Patrol boomer;
    public BoomerSounds(Patrol p)
    {
        boomer = p;
    }

    public void UpdateSoundsPosition()
    {
        AudioManager.instance.zombieIdle.transform.position = boomer.transform.position;
        AudioManager.instance.zombieStress.transform.position = boomer.transform.position;
        AudioManager.instance.zombieScream.transform.position = boomer.transform.position;
    }
}
