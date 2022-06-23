using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : Subs
{
    //un tipo de sub que es vintage y amarillo que se dispara por collider

    private Color dialogueColor;
    void Start()
    {
        dialogueColor = new Color(255f/255f, 205f/255f, 120f/255f, 1); //amarillito vintage
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
        subsCanvasText.fontStyle = FontStyle.Italic;
        subsCanvasText.color = dialogueColor;
        subsCanvasText.text = text;
        subsCanvasText.text = "-" + subsCanvasText.text; //agrega un guioncito vintage
        Invoke("Hide", time);
    }
}
