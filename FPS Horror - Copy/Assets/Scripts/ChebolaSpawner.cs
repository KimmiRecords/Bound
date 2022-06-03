using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChebolaSpawner : MonoBehaviour
{

    //Este script se lo agregas a un pickup para que haga spawnear un chebola al destruirse. por ej, los usb.

    //public GameObject desiredChebola; //para prender y apagar chebola en vez de instanciar y destruir
    public GameObject chebolaPrefab;
    public Vector3 desiredSpawnPosition;
    public int screamerID; //cual screamer reproduce este chebola

    MonsterMovement _mm;

    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded)
        { 
            return;
        }

        Instantiate(chebolaPrefab, desiredSpawnPosition, Quaternion.identity);
        //desiredChebola.SetActive(false);

        //_mm = desiredChebola.GetComponent<MonsterMovement>();
        _mm = chebolaPrefab.GetComponent<MonsterMovement>();
        _mm.desiredScreamer = screamerID;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(desiredSpawnPosition, 1);
    }
}
