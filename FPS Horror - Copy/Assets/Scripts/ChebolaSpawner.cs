using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChebolaSpawner : MonoBehaviour
{

    //Este script se lo agregas a un pickup para que haga spawnear un chebola al destruirse. por ej, los usb.

    public GameObject chebolaPrefab;
    public Vector3 desiredSpawnPosition;


    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) //esto es clave. solo va a instanciar si la escena esta activa. no sea cosa que queden instancias rancias colgando por ahi.
        { 
            return;
        }

        Instantiate(chebolaPrefab, desiredSpawnPosition, Quaternion.identity);
    }
}
