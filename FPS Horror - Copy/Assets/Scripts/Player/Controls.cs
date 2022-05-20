using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls
{
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
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerMovement.StopRunning();
        }

        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
    }
}
