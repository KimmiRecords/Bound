using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviFloor : MonoBehaviour
{
    //este script se lo pones a un trigger para que aplique slow a todo lo que lo atraviese
    //bueno, en realidad a todo lo que suscriba con IRalentizable.
    //por diego katabian
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IRalentizable>() != null)
        {
            var ralentizable = other.GetComponent<IRalentizable>();
            //print("entro " + ralentizable + " al trigger");
            ralentizable.EnterSlow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IRalentizable>() != null)
        {
            var ralentizable = other.GetComponent<IRalentizable>();
            //print("salio " + ralentizable + " del trigger");
            ralentizable.ExitSlow();
        }

    }
}
