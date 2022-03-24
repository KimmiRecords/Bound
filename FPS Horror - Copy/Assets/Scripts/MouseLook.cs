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


    float xRotation = 0f;
    void Start()
    {
        //Hace que el cursor desaparezca.
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        Ray ray = fpsCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * pickUpDistance, Color.red);

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

        if (Input.GetKeyDown(KeyCode.E) && sensedObj)
        {
            //Muestra en consola el nombre el tipo y la cantidad de objetos interactuados.
            Debug.LogFormat("Used {0} of Type {1} Amount: {2}", sensedObj.name, sensedObj.pickUpType, sensedObj.amount);
            DestroyImmediate(sensedObj.gameObject);
            sensedObj = null;
        }
    }
}
