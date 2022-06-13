using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject exp;
    public float expForce, radius;

    private void OnCollisionEnter(Collision other)
    {
        GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
        Destroy(_exp, 3);
    }
}
