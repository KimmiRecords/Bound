using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
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


    void Update()
    {

    }

    public void OpenDoor()
    {
        _doorAnim.SetBool("isOpening", true);
        //AudioManager.instance.PlayDoorOpen();
    }

    public void CloseDoor()
    {
        _doorAnim.SetBool("isOpening", false);
        //AudioManager.instance.PlayDoorClose();
    }

    

}
