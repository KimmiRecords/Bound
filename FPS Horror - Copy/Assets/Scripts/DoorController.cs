using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //este script se lo pones a un collider hijo de puerta para que esta se abra automaticamente al acercarte. 
    //las puertas que se abren con boton o placa de presion llaman a los metodos de este script.
    //por francisco serra

    [HideInInspector]
    public Animator _doorAnim;

    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        _doorAnim.SetBool("isOpening", true);
    }

    public void CloseDoor()
    {
        _doorAnim.SetBool("isOpening", false);
    }
}
