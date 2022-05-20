using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFrame : MonoBehaviour
{
    private float damageRatio;

    public GameObject ruidoBlanco;
    public RawImage ruidoBlancoRawImg;

    public GameObject damageFrame2;
    private RawImage damageFrame2RawImg;

    private float opacity;
    public float maxOpacity; //por ahi no quiero que el max sea 1, sino un poco menos

    void Start()
    {
        ruidoBlancoRawImg = ruidoBlanco.GetComponent<RawImage>();
        damageFrame2RawImg = damageFrame2.GetComponent<RawImage>();
    }

    void Update()
    {
        damageRatio = PlayerStats.instance.PlayerHp / PlayerStats.instance.playerHpMax; //damageRatio es 0 cuando estoy nuevo, es 1 cuando me mori
        opacity = 1 - damageRatio; //la opacidad. 1 es que se ve, 0 es invisible.
        opacity = Mathf.Clamp(opacity, 0, maxOpacity);

        if (damageRatio == 1)
        {
            ruidoBlanco.SetActive(false); //si no tengo daño, no hay ruido
            damageFrame2.SetActive(false);

        }
        else
        {
            ruidoBlanco.SetActive(true);
            ruidoBlancoRawImg.color = new Color(1, 0, 0, opacity); //cuando tengo daño, va apareciendo el recuadro de ruidoblanco

            damageFrame2.SetActive(true);
            damageFrame2RawImg.color = new Color(1, 1, 1, opacity);

        }

        //print("Damage taken ratio = " + damageRatio);
        //print("opacity = " + opacity);
    }
}
