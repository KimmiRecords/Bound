using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    //este script se lo pones a un collider bien grandote para que funcione como area de gas toxico
    //por mateo palma

    public float gasDamage;

    void OnTriggerStay(Collider collider)
    {
        if (collider.GetComponent<IGaseable>() != null)
        {
            var elotro = collider.GetComponent<IGaseable>();
            elotro.Gas(gasDamage * Time.deltaTime);
        }
    }
    public void GasPassiveDamage()
    {
        PlayerStats.instance.TakeDamage(gasDamage * Time.deltaTime);
    }
}
