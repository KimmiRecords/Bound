using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float verticalVelocity;
    private float groundedTimer;        // to allow jumping when going down ramps
    private float playerSpeed = 7f;
    private float jumpHeight = 3.0f;
    private float gravityValue = 12.81f;

    private void Start()
    {
        // always add a controller
        if (GetComponent<CharacterController>() != null)
        {
            controller = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            groundedTimer = 0.2f; //mientras este en el suelo
        }

        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime; //lo vuelve a 0
        }

        if (groundedPlayer && verticalVelocity < 0) //corta la caida cuando toco el suelo
        {
            verticalVelocity = 0f;
        }

        verticalVelocity -= gravityValue * Time.deltaTime; //aplica gravedad
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        move *= playerSpeed;

        if (PlayerStats.agency)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (groundedTimer > 0)
                {
                    groundedTimer = 0;
                    verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravityValue);
                }
            }
        }

        move.y = verticalVelocity;
            controller.Move(move * Time.deltaTime);

    }
}
