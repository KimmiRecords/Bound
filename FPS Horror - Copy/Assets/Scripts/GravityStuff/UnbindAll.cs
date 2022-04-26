using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbindAll : MonoBehaviour
{

    //este script prende y apaga la gravedad para TODOS los rigidbodies en escena. todo mal.
    private Rigidbody[] _allRBs;
    private bool _areBound;

    public Vector3 desiredGrav;

    private Vector3 alteredGrav;

    void Start()
    {
        _allRBs = FindObjectsOfType<Rigidbody>();
        _areBound = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleGravAll();
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _allRBs.Length; i++)
        {
            _allRBs[i].AddForce(alteredGrav, ForceMode.Force); //aplica alteredGrav constantemente
        }
    }

    public void ToggleGravAll()
    {
        for (int i = 0; i < _allRBs.Length; i++)
        {
            if (_areBound) //si estan atados
            {
                _allRBs[i].useGravity = false; //los suelto
                alteredGrav = desiredGrav;
                //_areBound = false;
            }
            else
            {
                _allRBs[i].useGravity = true; //los ato de nuevo
                alteredGrav = Vector3.zero;
                //_areBound = true;
            }
        }

        _areBound = !_areBound;

    }
}
