using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CopyColor : MonoBehaviour
{
    //este script se lo adjuntas a un Text para que copie el color de otro text
    //por diego katabian

    public Text aQuienCopio;
    public Text yo;

    public bool copiarSoloAlpha;

    void Update()
    {
        if (copiarSoloAlpha)
        {
            yo.color = new Color(yo.color.r, yo.color.g, yo.color.b, aQuienCopio.color.a);
        }
        else
        {
            yo.color = new Color(aQuienCopio.color.r, aQuienCopio.color.g, aQuienCopio.color.b, aQuienCopio.color.a);

        }
    }
}
