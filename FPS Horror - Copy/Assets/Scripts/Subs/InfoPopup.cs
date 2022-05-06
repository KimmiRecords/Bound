using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPopup : Subs
{
    //este script se lo adjuntas a un Interactable que quieras que muestre un mensaje en pantalla mientras lo miras


    private Interactable yo;

    public MouseLook mouseLook;
    
    void Start()
    {
        if (GetComponent<Interactable>() != null)
        {
            yo = GetComponent<Interactable>();
        }

        if (mouseLook == null)
        {
            mouseLook = FindObjectOfType<MouseLook>();
        }
    }

    void Update()
    {
        if (mouseLook.sensedObj == yo) //los infopopup se disparan por raycast
        {
            Show(desiredText, desiredTime);
        }

    }
    private void OnTriggerEnter(Collider player) //los dialogue se disparan por con colliders
    {
        if (player.gameObject.layer == 3) //la 3 es la del player, obvio
        {
            Show(desiredText, desiredTime);
        }
    }
    public override void Show(string text, float time)
    {
        subsCanvasText.text = text;
        Invoke("Hide", time);
    }

    public override void Hide()
    {
        subsCanvasText.text = "";
    }

    public void OnDestroy()
    {
        Hide();
    }


}
