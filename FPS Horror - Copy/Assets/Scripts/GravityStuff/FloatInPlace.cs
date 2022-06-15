using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInPlace : MonoBehaviour
{
    //este script se lo pones al padre para que sus hijos floten en el lugar
    //por diego katabian

    public Vector3 desiredGrav;

    Rigidbody[] _allRBs;
    float _timer;
    Vector3 _finalGrav;

    void Start()
    {
        _allRBs = GetComponentsInChildren<Rigidbody>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _finalGrav.x = Mathf.Sin(_timer) * desiredGrav.x;
        _finalGrav.y = Mathf.Sin(_timer) * desiredGrav.y;
        _finalGrav.z = Mathf.Sin(_timer) * desiredGrav.z;

        //finalGrav = Mathf.Clamp(finalGrav, 0, 1);

        for (int i = 0; i < _allRBs.Length; i++)
        {
            _allRBs[i].useGravity = false;
            _allRBs[i].AddForce(_finalGrav, ForceMode.Force);
        }
    }

}
