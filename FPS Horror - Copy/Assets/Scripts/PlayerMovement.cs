using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private float _verticalVelocity;
    private float _groundedTimer;       // para que detecte piola en rampas
    public float _playerSpeed;
    public float _jumpHeight;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto

    public Vector3 move;

    private void Start()
    {
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
            AudioManager.instance.PlayJumpDown();
        }

        _verticalVelocity -= gravityValue * Time.deltaTime; //aplica gravedad extra
        move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        //move = move.normalized;
        //print(move.magnitude);
        move *= _playerSpeed;

        if (PlayerStats.agency)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (_groundedTimer > 0)
                {
                    AudioManager.instance.StopPasos();
                    AudioManager.instance.PlayJumpUp();
                    _groundedTimer = 0;
                    _verticalVelocity += Mathf.Sqrt(_jumpHeight * 2 * gravityValue); //saltar en realidad le da velocidad vertical nomas
                }
            }
        }

        move.y = _verticalVelocity;
        _controller.Move(move * Time.deltaTime); //para mover al character controller hay que usar el metodo .Move



    }
}
