using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private float _verticalVelocity;
    private float _groundedTimer;        // to allow jumping when going down ramps
    private float _playerSpeed = 7f;
    private float _jumpHeight = 3.0f;
    public float gravityValue;

    private void Start()
    {
        // always add a controller
        if (GetComponent<CharacterController>() != null)
        {
            _controller = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        bool groundedPlayer = _controller.isGrounded;
        if (groundedPlayer)
        {
            _groundedTimer = 0.2f; //mientras este en el suelo
        }

        if (_groundedTimer > 0)
        {
            _groundedTimer -= Time.deltaTime; //lo vuelve a 0
        }

        if (groundedPlayer && _verticalVelocity < 0) //corta la caida cuando toco el suelo
        {
            _verticalVelocity = 0f;
        }

        _verticalVelocity -= gravityValue * Time.deltaTime; //aplica gravedad
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        move *= _playerSpeed;

        if (PlayerStats.agency)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (_groundedTimer > 0)
                {
                    _groundedTimer = 0;
                    _verticalVelocity += Mathf.Sqrt(_jumpHeight * 2 * gravityValue);
                }
            }
        }

        move.y = _verticalVelocity;
            _controller.Move(move * Time.deltaTime);

    }
}
