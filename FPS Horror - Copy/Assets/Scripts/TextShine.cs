using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextShine : MonoBehaviour
{
    public Text text;
    public Color startColor;
    void Start()
    {
        if (GetComponent<Text>() != null)
        {
            text = GetComponent<Text>();
        }
        startColor = text.color;
    }

    void Update()
    {
        //adjunta este codigo a cualquier texto UI
        //hace aparecer y desaparecer el texto
        text.color = startColor + new Color(0, 0, 0, Mathf.Sin(2 * Time.time));

    }
}
