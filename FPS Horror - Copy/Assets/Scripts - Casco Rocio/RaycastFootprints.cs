using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFootprints : Footprints
{
    public FlashlightLife timerFlashlight;


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
        {
            if (timerFlashlight.timer > 0 && hit.transform.tag == "footprints")
            {

                seeFootprints[0].SetActive(true);

            }
            else if (timerFlashlight.timer <= 0 || hit.transform.tag != "footprints")
            {
                seeFootprints[0].SetActive(false);
            }
            if (timerFlashlight.timer > 0 && hit.transform.tag == "footprints1")
            {

                seeFootprints[1].SetActive(true);

            }
            else if (timerFlashlight.timer <= 0 || hit.transform.tag != "footprints1")
            {
                seeFootprints[1].SetActive(false);
            }
            if (timerFlashlight.timer > 0 && hit.transform.tag == "footprints2")
            {

                seeFootprints[2].SetActive(true);

            }
            else if (timerFlashlight.timer <= 0 || hit.transform.tag != "footprints2")
            {
                seeFootprints[2].SetActive(false);
            }

        }
    }
}
