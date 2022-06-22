using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Subs : MonoBehaviour
{
    //este script es padre de otros. muestra un texto a modo de subtitulos.

    //los hijos de este script son las distintas maneras de mostrar subs.
    //polymorphean el metodo Show para cambiarle el formato u otras cosas.
    //TP2 - Diego Katabian

    [TextArea(2,4)]
    public string desiredText;

    public float desiredTime;
    public Text subsCanvasText; //el componente Text del canvas

    Color initialColor;

    void Start()
    {
        initialColor = subsCanvasText.color;
    }

    public virtual void Show(string text, float time)
    {
        subsCanvasText.color = initialColor;
        subsCanvasText.text = text;
        Invoke("Hide", time);
    }

    public virtual void Hide()
    {
        subsCanvasText.text = "";
        Destroy(this.gameObject);
    }
}
