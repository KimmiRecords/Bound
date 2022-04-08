using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPopup : MonoBehaviour
{
    private Interactable yo;

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

    public void Show(string text, float time)
    {
        popupText.text = text;
        Invoke("Hide", time);
    }

    public void Hide()
    {
        popupText.text = "";
    }
}
