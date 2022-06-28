using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IRalentizable
{
    //el movimiento del player. con character controller y a mano
    //llama por composicion a playeranimations y controls
    //por diego katabian, francisco serra, valentino roman, mateo palma, rocio casco.

    [HideInInspector]
    public float playerSpeed;

    public float walkingSpeed;
    public float runningSpeed;
    public float jumpHeight;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto
    public bool agency = true;

    float _verticalVelocity;
    float _speedModifier;
    float _groundedTimer;
    Vector3 _move;

    public CharacterController controller;
    public PlayerAnimations pAnims;
    public Controls controls;

    Animator _anim;

    void Start()
    {
        if (GetComponent<CharacterController>() != null)
        {
            controller = GetComponent<CharacterController>();
        }

        if (GetComponent<Animator>() != null)
        {
            _anim = GetComponent<Animator>();
        }

        playerSpeed = walkingSpeed;
        _speedModifier = 1;
        controls = new Controls(this);
        pAnims = new PlayerAnimations(_anim); //construyo scripts x composicion

        PlayerStats.instance.OnDeath += TPToCheckpoint; //ya enterate
    }

    void Update()
    {
        controls.CheckControls();

        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            _groundedTimer = 0.2f; //mientras este en el suelo
            pAnims.StopJumping();
            pAnims.StopFalling();
            pAnims.PlayLanding();
        }

        if (_groundedTimer > 0)
        {
            _groundedTimer -= Time.deltaTime;
        }

        if (!groundedPlayer && _verticalVelocity <= -2f) //si esta cayendo pero no tocando el suelo empieza a caer
        {
            pAnims.StopJumping();
            pAnims.PlayFalling();
        }

        if (groundedPlayer && _verticalVelocity <= 0) //corta la caida cuando toco el suelo
        {
            _verticalVelocity = 0f;
            AudioManager.instance.PlayJumpDown();
        }

        _verticalVelocity -= gravityValue * Time.deltaTime; //aplica gravedad extra
        _move = transform.right * controls.h + transform.forward * controls.v; //cargo mi vector movimiento

        if (_move.magnitude > 1)
        {
            _move = _move.normalized;
        }

        if (controls.isJump)
        {
            if (_groundedTimer > 0)
            {
                AudioManager.instance.StopPasos();
                AudioManager.instance.PlayJumpUp();
                _groundedTimer = 0;
                _verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravityValue); //saltar en realidad le da velocidad vertical nomas
                pAnims.PlayJumping();
                pAnims.StopLanding();
                controls.isJump = false;
            }
        }

        _move *= playerSpeed * _speedModifier;
        _move.y = _verticalVelocity; //sigo cargando el vector movieminto
        controller.Move(_move * Time.deltaTime); //aplico el vector movieminto al character controller, con el metodo .Move

        if (agency)
        {
            pAnims.CheckMagnitude(_move.x + _move.z); //en el script de playerAnimations, chequea si me estoy moviendo o no
        }
    }

    public void Run()
    {
        playerSpeed = runningSpeed;
    }
    public void StopRunning()
    {
        playerSpeed = walkingSpeed;
    }
    void TPToCheckpoint(Vector3 cp)
    {
        AudioManager.instance.PlayTPToCheckpoint();
        controller.enabled = false; //apago el character controller antes de moverlo
        transform.position = cp;
        controller.enabled = true;
    }
    public void MoveForward()
    {
        _move = transform.forward * playerSpeed * _speedModifier;
        controller.Move(_move * Time.deltaTime);
        pAnims.CheckMagnitude(_move.x + _move.z); //en el script de playerAnimations, chequea si me estoy moviendo o no
    }
    public void EnterSlow()
    {
        _speedModifier = 0.5f;
        AudioManager.instance.TriggerSound(AudioManager.instance.geigerCounter, 2, 0, 1, true);
    }
    public void ExitSlow()
    {
        _speedModifier = 1;
        AudioManager.instance.TriggerSound(AudioManager.instance.geigerCounter, 2, 0, 1, false);
    }
}
