using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //el movimiento del player. con character controller y a mano
    //por todos, basicamente.

    private CharacterController _controller;
    private float _verticalVelocity;
    private float _groundedTimer;       // para que detecte piola en rampas
    public float _playerSpeed;
    public float _jumpHeight;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto

    private Vector3 move;

    Animator _anim;
    PlayerAnimations _pAnims;

    private void Start()
    {
        if (GetComponent<CharacterController>() != null)
        {
            _controller = GetComponent<CharacterController>();
        }

        if (GetComponent<Animator>() != null)
        {
            _anim = GetComponent<Animator>();
        }

        _pAnims = new PlayerAnimations(_anim); //construyo el script de playerAnimations
    }

    void Update()
    {
        bool groundedPlayer = _controller.isGrounded;
        if (groundedPlayer)
        {
            _groundedTimer = 0.2f; //mientras este en el suelo
            _pAnims.StopJumping();
            _pAnims.StopFalling();
            _pAnims.PlayLanding();
        }

        if (_groundedTimer > 0)
        {
            _groundedTimer -= Time.deltaTime; //lo vuelve a 0
        }

        if (!groundedPlayer && _verticalVelocity <= -8f) //si esta cayendo pero no tocando el suelo empieza a caer
        {
            _pAnims.StopJumping();
            _pAnims.PlayFalling();
        }

        if (groundedPlayer && _verticalVelocity <= 0) //corta la caida cuando toco el suelo
        {
            _verticalVelocity = 0f;
            AudioManager.instance.PlayJumpDown();
        }

        _verticalVelocity -= gravityValue * Time.deltaTime; //aplica gravedad extra
        move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        if (move.magnitude > 1)
        {
            move = move.normalized;
        }

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
                    _pAnims.PlayJumping();
                    _pAnims.StopLanding();
                }
            }
        }

        move.y = _verticalVelocity;
        _controller.Move(move * Time.deltaTime); //para mover al character controller hay que usar el metodo .Move


        _pAnims.CheckMagnitude(move.x + move.z); //en el script de playerAnimations, chequea si me estoy moviendo o no
    }
}
