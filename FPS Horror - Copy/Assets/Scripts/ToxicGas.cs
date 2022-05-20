using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    //este script se lo pones a un collider bien grandote para que funcione como area de gas toxico
    //por mateo

    public float GasDamage;
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == 3) 
        {
            GasPassiveDamage();
        }
    }
    public void GasPassiveDamage()
    {
        PlayerStats.instance.TakeDamage(GasDamage);
        //print("Me queda " + PlayerStats.playerHp + " de vida");
    }
}
