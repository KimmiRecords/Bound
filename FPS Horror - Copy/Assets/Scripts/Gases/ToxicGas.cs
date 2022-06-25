using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    //este script se lo pones a un collider bien grandote para que funcione como area de gas toxico
    //TP2 - Mateo Palma

    public float gasDamage;

    void OnTriggerStay(Collider collider)
    {
        if (collider.GetComponent<IGaseable>() != null)
        {
            var elotro = collider.GetComponent<IGaseable>();
            elotro.Gas(gasDamage * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IGaseable>() != null)
        {
            var elotro = other.GetComponent<IGaseable>();
            elotro.EnterGas();
        }
    }

}
