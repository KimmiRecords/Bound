using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChebolaSpawner : MonoBehaviour
{
    public GameObject chebolaPrefab;
    public Vector3 desiredSpawnPosition;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnApplicationQuit()
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
