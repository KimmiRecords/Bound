using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    //este script se lo pones a un collider bien grandote para que funcione como area de gas toxico
    //por mateo

    public float GasDamage;
    public Interactable quienMeControla;
    public MouseLook mouseLook;
    
    void Update()
    {
        if (mouseLook.sensedObj == quienMeControla)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                DestroyGas();
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == 3) 
        {
            GasPassiveDamage();
        }
    }

    public void GasPassiveDamage()
    {
        PlayerStats.playerHp -= GasDamage;
        //print("Me queda " + PlayerStats.playerHp + " de vida");
        
    }

    public void DestroyGas()
    {
        Destroy(this.gameObject);
    }
}
