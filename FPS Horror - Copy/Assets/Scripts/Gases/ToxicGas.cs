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
        if (collider.gameObject.layer == 3) 
        {
            GasPassiveDamage();
        }
        //if collider.GetComponent<IGaseable>() != null
        //var elotro = collider.GetComponent<IGaseable>();
        //elotro.TakeDamage();

        //en los que se afectan, agregar ", IGaseable" y el metodo.
        //crear la interfaz con los metodos obligatorios.
        
    }
    public void GasPassiveDamage()
    {
        PlayerStats.instance.TakeDamage(gasDamage * Time.deltaTime);
    }
}
