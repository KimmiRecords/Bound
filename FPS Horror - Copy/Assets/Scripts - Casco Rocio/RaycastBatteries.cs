using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastBatteries : MonoBehaviour
{
    public int batteriesObtained;
    public int currentBatteries;
    public int batteryRecharge;
    public Text count;
    public FlashlightLife wasteBattery;


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
                count.text = "Baterias: " + batteriesObtained.ToString("f0");

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
