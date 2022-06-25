using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGaseable
{
    //todos los que sean afectados por el gas tienen este metodo
    //TP2 - Mateo Palma y Francisco Serra

    void Gas(float d);
    void EnterGas();
}
