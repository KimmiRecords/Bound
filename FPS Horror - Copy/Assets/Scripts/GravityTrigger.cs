using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    //este script se lo adjuntas a un interactable. cuando interactuas con el, se togglea la grav para todos los graviobjetos

    private Interactable yo;

    public MouseLook mouseLook;
    //public InvertGravity invertGravity;

    private InvertGravity[] allGraviBoxes;
    
    void Start()
    {
        if (GetComponent<Interactable>() != null)
        {
            yo = GetComponent<Interactable>();
        }

        allGraviBoxes = FindObjectsOfType<InvertGravity>();
    }

    void Update()
    {
        if (mouseLook.sensedObj == yo)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))  //tuki apreto E y se togglea la gravedad
            {
                //a todos
                for (int i = 0; i < allGraviBoxes.Length; i++)
                {
                    allGraviBoxes[i].ToggleGrav();
                }

                //solo al elegido
                //invertGravity.ToggleGrav();
            }
        }
    }
}
