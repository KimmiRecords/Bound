using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //el movimiento del player. con character controller y a mano
    //llama por composicion a playeranimations y controls
    //por diego katabian, francisco serra, valentino roman, mateo palma, rocio casco.

    public float playerSpeed;
    public float runningSpeed;
    public float jumpHeight;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto


    float _verticalVelocity;

    float _groundedTimer;
    float _walkingSpeed;
    Vector3 _move;
    CharacterController _controller;
    Animator _anim;
    PlayerAnimations _pAnims;
    Controls _controls;

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

        _walkingSpeed = playerSpeed;
        _controls = new Controls(this);
        _pAnims = new PlayerAnimations(_anim); //construyo el script de playerAnimations

    }

    void Update()
    {
        _controls.CheckControls();

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
            _groundedTimer -= Time.deltaTime;
        }

        if (!groundedPlayer && _verticalVelocity <= -2f) //si esta cayendo pero no tocando el suelo empieza a caer
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
        _move = transform.right * _controls.h + transform.forward * _controls.v; //cargo mi vector movimiento

        if (_move.magnitude > 1)
        {
            _move = _move.normalized;
        }

        if (_controls.isJump)
        {
            if (_groundedTimer > 0)
            {
                AudioManager.instance.StopPasos();
                AudioManager.instance.PlayJumpUp();
                _groundedTimer = 0;
                _verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravityValue); //saltar en realidad le da velocidad vertical nomas
                _pAnims.PlayJumping();
                _pAnims.StopLanding();
                _controls.isJump = false;
            }
        }

        _move *= playerSpeed;
        _move.y = _verticalVelocity; //sigo cargando el vector movieminto
        _controller.Move(_move * Time.deltaTime); //aplico el vector movieminto al character controller, con el metodo .Move

        _pAnims.CheckMagnitude(_move.x + _move.z); //en el script de playerAnimations, chequea si me estoy moviendo o no
    }

    public void Run()
    {
        playerSpeed = runningSpeed;
    }

    public void StopRunning()
    {
        playerSpeed = _walkingSpeed;
    }
}
