using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Subs : MonoBehaviour
{
    //este script es padre de otros. muestra un texto a modo de subtitulos.

    //los hijos de este script son las distintas maneras de mostrar subs.
    //overridean el metodo Show para cambiarle el formato u otras cosas.

    public Text subsCanvasText; //el componente Text del canvas

    [TextArea(2,4)]
    public string desiredText;

    public float desiredTime;

    private Color initialColor;

    void Start()
    {
        initialColor = subsCanvasText.color;
    }

    void Update()
    {
        
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

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, 1);
    }
}
