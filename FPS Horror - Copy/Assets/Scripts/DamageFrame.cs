using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFrame : MonoBehaviour
{
    private float damageRatio;

    public GameObject ruidoBlanco;
    private RawImage ruidoBlancoRawImg;

    public GameObject damageFrame2;
    private RawImage damageFrame2RawImg;

    private float alpha;

    void Start()
    {
        ruidoBlancoRawImg = ruidoBlanco.GetComponent<RawImage>();
        damageFrame2RawImg = damageFrame2.GetComponent<RawImage>();

    }

    void Update()
    {
        damageRatio = (PlayerStats.playerHp / PlayerStats.playerHpMax); //damageRatio es 0 cuando estoy nuevo, es 1 cuando me mori
        alpha = 1 - damageRatio;

        if (damageRatio == 1)
        {
            ruidoBlanco.SetActive(false); //si no tengo daño, no hay ruido
            damageFrame2.SetActive(false);

        }
        else
        {
            ruidoBlanco.SetActive(true);
            ruidoBlancoRawImg.color = new Color(1, 0, 0, alpha); //cuando tengo daño, va apareciendo el recuadro de ruidoblanco

            damageFrame2.SetActive(true);
            damageFrame2RawImg.color = new Color(1, 1, 1, alpha); //cuando tengo daño, va apareciendo el recuadro de ruidoblanco

        }

        //print("Damage taken ratio = " + damageRatio);
        //print("alpha = " + alpha);
    }
}
