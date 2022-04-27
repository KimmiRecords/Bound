using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGas : MonoBehaviour
{
    public float GasDamage;

    public Interactable quienMeControla;

    public MouseLook mouseLook;

    public DamageFrame DF;
    void Start()
    {
        
    }

    
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
        DF.ruidoBlancoRawImg.color = new Color(0, 1, 0, DF.ruidoBlancoRawImg.color.a);
        print("Me queda " + PlayerStats.playerHp + " de vida");
        
    }

    public void DestroyGas()
    {

        Destroy(this.gameObject);

    }
}
