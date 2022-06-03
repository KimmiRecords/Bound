using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{
    private float spin;
    
    void Update()
    {
        spin += 0.1f;
        transform.rotation = Quaternion.Euler(-90, -90, spin);
    }
}
