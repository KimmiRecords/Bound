using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running
{
    //este script es construido por playermovement. 
    //crea los valores que manejan la velocidad al caminar y correr. 
    //cuando tocas SHIFT corres papa

    PlayerMovement _pm;

    float _currentSpeed; //la que voy a ir cambiando
    float _walkingSpeed; //la fija lenta
    float _runningSpeed; //la fija rapida
    float _runningMultiplier; //la rapida es en realidad la walking * 1.17

    public Running(PlayerMovement playerMovement)
    {
        _pm = playerMovement;
        _runningMultiplier = 1.17f;

        _walkingSpeed = _pm.playerSpeed; //fijo la walkingspeed al momento de construccion
        _runningSpeed = _walkingSpeed * _runningMultiplier; //y ya que estoy, la running speed
    }

    public void Run()
    {
        _pm.playerSpeed = _runningSpeed;
    }

    public void StopRunning()
    {
        _pm.playerSpeed = _walkingSpeed;
    }

}
