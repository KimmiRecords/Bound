using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPopup : MonoBehaviour
{
    //este script se lo adjuntas a un interactable que quieras que muestre un mensaje en pantalla mientras lo miras

    private Interactable yo;

    [TextArea(2, 4)]
    public string message;
    public float messageTime;

    public Text popupText;
    public MouseLook mouseLook;
    
    void Start()
    {
        if (GetComponent<Text>() != null)
        {
           popupText = GetComponent<Text>();
        }
        if (GetComponent<Interactable>() != null)
        {
            yo = GetComponent<Interactable>();
        }
    }

    void Update()
    {
        if (mouseLook.sensedObj == yo)
        {
            Show(message, messageTime);
        }
    }

    public virtual void Show(string text, float time)
    {
        popupText.text = text;
        Invoke("Hide", time);
    }

    public virtual void Hide()
    {
        popupText.text = "";
    }
}
