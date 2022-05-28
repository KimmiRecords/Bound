using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls
{
    //clase construida por playerMovement
    //por diego katabian

    public float h;
    public float v;
    public bool isJump;

    PlayerMovement _playerMovement;

    public Controls(PlayerMovement pm)
    {
        _playerMovement = pm;
        isJump = false;
    }
    public void CheckControls()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _playerMovement.Run();
            AudioManager.instance.isRunning = true;
            AudioManager.instance.ChangePitchPasos(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerMovement.StopRunning();
            AudioManager.instance.isRunning = false;
            AudioManager.instance.ChangePitchPasos(false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJump = false;
        }
    }
}
