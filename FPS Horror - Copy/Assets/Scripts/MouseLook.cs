using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //controla la vista FirstPerson y ademas tiene raycast en la camara.
    //este script incluye algunas interacciones del jugador con objetos
    //la mayoria de este script lo hizo Fran, despues DK agrego algunas cositas

    public Transform playerBody;
    public Camera fpsCamera = null;

    public float mouseSensitivity;
    float xRotation = 0f;

    public float pickUpDistance = 100f;

    public Interactable sensedObj = null;
    public GameObject usb3;
    public GameObject manito;

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


        //LOGICA DEL RAYCAST -- por Fran
        Ray ray = fpsCamera.ScreenPointToRay(Input.mousePosition);
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

        //interactuamos con E -- por Fran

        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && sensedObj)
        {
            //Debug.LogFormat("Grabbed {0} of Type {1} Amount: {2}", sensedObj.name, sensedObj.pickUpType, sensedObj.amount);

            if (sensedObj.pickUpType != EnumPickUpType.solo_infoPopup)
            {
                AudioManager.instance.PlayPickup(1.1f);
            }

            if (sensedObj.pickUpType == EnumPickUpType.item_usb)
            {
                PlayerStats.usbsCollected++;
                print("Conseguiste un Pendrive. Solo te faltan " + (4 - PlayerStats.usbsCollected) + " para ganar.");
            }

            if (sensedObj.gameObject == usb3)  //hace aparecer al Chebola justo despues de agarrar el tercer usb. -- por DK
            {
                MonsterMovement.instance.TPBehindYou(12f);
                print("Tenes al Chebola atras tuyo.");
            }

            if (sensedObj.pickUpType == EnumPickUpType.item_flashlight)
            {
                PlayerStats.hasFlashlight = true;
                print("Conseguiste la linterna. Toca Q para ver.");
            }

            //si es un pickup, lo destruye -- por Fran
            if (sensedObj.pickUpType == EnumPickUpType.item_usb || sensedObj.pickUpType == EnumPickUpType.item_battery || 
                sensedObj.pickUpType == EnumPickUpType.item_hp || sensedObj.pickUpType == EnumPickUpType.item_flashlight)
            {
                DestroyImmediate(sensedObj.gameObject);
                sensedObj = null;
            }
        }
    }
}
