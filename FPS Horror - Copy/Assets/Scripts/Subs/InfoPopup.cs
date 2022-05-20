using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPopup : Subs
{
    //este script se lo adjuntas a un Interactable que quieras que muestre un mensaje en pantalla mientras lo miras

    Interactable yo;
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
            print("estoy mirando al metal cabinet");
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
        if (!this.gameObject.scene.isLoaded) 
        {
            return;
        }
        Hide();
    }
}
