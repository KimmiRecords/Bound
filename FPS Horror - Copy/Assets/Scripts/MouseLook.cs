using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //controla la vista FP y ademas tiene raycast en la camara.

    public Transform playerBody;

    public Camera fpsCamera = null;

    public float mouseSensitivity = 100f;

    public float pickUpDistance = 100f;

    public Interactable sensedObj = null;
    public GameObject usb3;


    float xRotation = 0f;
    void Start()
    {
        //Hace que el cursor desaparezca.
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {

        //LOGICA DE ROTACION DE LA MIRA DEL MOUSE
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);



        //LOGICA DEL RAYCAST
        Ray ray = fpsCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * pickUpDistance, Color.blue);

        if (Physics.Raycast(ray, out hit, pickUpDistance))
        {
            //Si le pegamos a algo.
            Interactable obj = hit.collider.GetComponent<Interactable>();
            if (obj)
            {
                sensedObj = obj;
            }
            else
            {
                sensedObj = null;
            }
        }
        else
        {
            //si no le pegamos a nada.
            sensedObj = null;
        }

        if (Input.GetKeyDown(KeyCode.E) && sensedObj)//interactuamo con E
        {
            //Muestra en consola el nombre el tipo y la cantidad de objetos interactuados.
            Debug.LogFormat("Grabbed {0} of Type {1} Amount: {2}", sensedObj.name, sensedObj.pickUpType, sensedObj.amount);

            if (sensedObj.pickUpType == EnumPickUpType.item_usb)
            {
                PlayerStats.usbsCollected++;
                print("Conseguiste un Pendrive. Solo te faltan " + (4 - PlayerStats.usbsCollected) + " para ganar.");
            }

            if (sensedObj.gameObject == usb3)
            {
                Vector3 tpPos = new Vector3(131, 2, -35);
                MonsterMovement.instance.TPToPosition(tpPos);
                print("Tenes al Chebola atras tuyo");

            }

            DestroyImmediate(sensedObj.gameObject);
            sensedObj = null;
        }
    }
}
