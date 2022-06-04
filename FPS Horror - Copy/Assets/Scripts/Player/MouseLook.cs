using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //controla la vista FirstPerson y ademas tiene raycast para interactables en la camara.
    //este script incluye algunas interacciones del jugador con objetos
    //por francisco serra y diego katabian

    public Transform playerBody;
    public Camera fpsCamera = null;
    public float mouseSensitivity;
    public float pickUpDistance;
    public Interactable sensedObj = null;
    public GameObject manito;

    float xRotation = 0f;

    void Start()
    {
        //Hace que el cursor desaparezca.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //LOGICA DE ROTACION DE LA MIRA DEL MOUSE -- por Fran
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; //el input.getaxis va hasta el valor y vuelve a 0, por eso hay que restarlo y no solo modificarlo.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rota la camara en x

        playerBody.Rotate(Vector3.up * mouseX); 


        //interactuo con E -- por Fran
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && sensedObj)
        {
            sensedObj.Interact(); //llamo al metodo comun a todos los interactables
                                  //si es un hijo de interactable, va a polimorfear.
        }
    }

    private void FixedUpdate()
    {
        //LOGICA DEL RAYCAST -- por Fran

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * pickUpDistance, Color.blue);

        if (Physics.Raycast(ray, out hit, pickUpDistance))
        {
            //Si le pegamos a algo interactable .
            Interactable obj = hit.collider.GetComponent<Interactable>();
            if (obj)
            {
                sensedObj = obj;
                if (obj.muestraManito)
                {
                    manito.SetActive(true);
                }
            }
            else
            {
                sensedObj = null;
                manito.SetActive(false);
            }
        }
        else
        {
            //si no le pegamos a nada.
            sensedObj = null;
            manito.SetActive(false);
        }
    }
}
