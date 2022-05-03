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

                seeFootprints.SetActive(true);

            }
            else if (timerFlashlight.timer <= 0 || hit.transform.tag != "footprints")
            {
                seeFootprints.SetActive(false);
            }

        }
    }
}
