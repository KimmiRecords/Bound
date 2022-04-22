using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reading : InfoPopup
{
    //un tipo de sub que es recto y blanco

    private Color readingColor;
    void Start()
    {
        readingColor = new Color(255f / 255f, 255f / 255f, 205f / 255f, 1); //blanquito vintage

    }

    void Update()
    {

    }

    public override void Show(string text, float time)
    {
        popupText.fontStyle = FontStyle.Normal;
        popupText.color = readingColor;
        popupText.text = text;
        popupText.text = "''" + popupText.text + "''"; //agrega las quotes
        Invoke("Hide", time);
    }
}