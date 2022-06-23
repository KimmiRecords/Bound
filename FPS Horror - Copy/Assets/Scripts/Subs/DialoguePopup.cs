using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopup : InfoPopup
{
    private Color dialogueColor;

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

        dialogueColor = new Color(255f / 255f, 205f / 255f, 120f / 255f, 1); //amarillito vintage

    }

    void Update()
    {
        if (mouseLook.sensedObj == yo) //los infopopup se disparan por raycast
        {
            Show(desiredText, desiredTime);
        }
    }

    public override void Show(string text, float time)
    {
        subsCanvasText.fontStyle = FontStyle.Italic;
        subsCanvasText.color = dialogueColor;
        subsCanvasText.text = text;
        subsCanvasText.text = "-" + subsCanvasText.text; //agrega un guioncito vintage
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
