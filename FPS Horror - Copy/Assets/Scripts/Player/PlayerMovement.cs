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
    private float _walkingSpeed;
    public float playerSpeed;
    public float runningSpeed;
    public float jumpHeight;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto

    private Vector3 _move;

    Animator _anim;
    PlayerAnimations _pAnims;
    //Running _run;

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
        _pAnims = new PlayerAnimations(_anim); //construyo el script de playerAnimations

        //_run = new Running(this); //construyo el script de runnin

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
            _groundedTimer -= Time.deltaTime;
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
        _move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical"); //cargo mi vector movimiento

        if (_move.magnitude > 1)
        {
            _move = _move.normalized;
        }

        //SALTA CON SPACEBAR.
        if (Input.GetButtonDown("Jump"))
        {
            if (_groundedTimer > 0)
            {
                AudioManager.instance.StopPasos();
                AudioManager.instance.PlayJumpUp();
                _groundedTimer = 0;
                _verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravityValue); //saltar en realidad le da velocidad vertical nomas
                _pAnims.PlayJumping();
                _pAnims.StopLanding();
            }
        }

        //CORRE CON SHIFT.
        //INTENTE HACERLO ANDAR DESDE OTRO CODIGO X COMPO PERO NO PUDE
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = runningSpeed;
            print("toque shift. mi speed es " + playerSpeed);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = _walkingSpeed;
            print("solte shift. mi speed es " + playerSpeed);
        }

        _move *= playerSpeed;
        _move.y = _verticalVelocity; //sigo cargando el vector movieminto
        _controller.Move(_move * Time.deltaTime); //aplico el vector movieminto al character controller, con el metodo .Move
        _pAnims.CheckMagnitude(_move.x + _move.z); //en el script de playerAnimations, chequea si me estoy moviendo o no
    }
}
