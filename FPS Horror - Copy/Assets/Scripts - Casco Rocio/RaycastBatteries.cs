using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastBatteries : MonoBehaviour
{
    
    private int             batteriesObtained = 0;
    private int             currentBatteries  = 1;
    public  int             batteryRecharge; //cuanto recarga cada pickup
    public  Text            count; //cuantos pickups de bateria conseguiste
    public  FlashlightLife  wasteBattery; //cantidad de vida de bateria


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
        {
            if (hit.transform.tag == "batteries" && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
            {
                Destroy(hit.transform.gameObject);
                batteriesObtained += currentBatteries;
                Debug.Log("bateria obtenida");
                count.text = "batteries: " + batteriesObtained.ToString("f0") + "/3";

                AudioManager.instance.PlayPickup(1);

                wasteBattery.timer += batteryRecharge;

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }
}
