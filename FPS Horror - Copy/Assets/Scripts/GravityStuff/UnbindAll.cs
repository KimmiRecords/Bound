using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbindAll : MonoBehaviour
{
    //este script prende y apaga la gravedad para TODOS los rigidbodies en escena. todo mal.
    //bound significa "atado", en este caso, a la gravedad. si esta bound, le afecta la gravedad normal. si esta unbound, sale volando.
    //por diego katabian

    public Vector3 desiredGrav; //la gravedad con la que quiero reemplazar a la normal. usualmente usamos y=1 para que sea hacia arriba

    Rigidbody[] _allRBs;
    bool _areBound;
    Vector3 alteredGrav;

    void Start()
    {
        _allRBs = FindObjectsOfType<Rigidbody>(); //hallo todos los rigidbodies de la escena
        _areBound = true;
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

        print("Afecté a " + _allRBs.Length + " rigidbodies.");
        _areBound = !_areBound;

    }
}
