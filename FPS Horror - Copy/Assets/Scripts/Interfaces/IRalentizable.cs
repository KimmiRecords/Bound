using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRalentizable
{
    //existe un suelo especial que ralentiza objetos
    //los objetos que sean afectados se adhieren a esta interfaz
    //TP2 - Diego Katabian y Valentino Roman
    void EnterSlow();
    void ExitSlow();

}
