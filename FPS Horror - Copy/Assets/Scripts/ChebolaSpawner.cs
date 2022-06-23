using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChebolaSpawner : MonoBehaviour
{
    //Este script se lo agregas a un pickup para que haga spawnear un chebola al destruirse. por ej, los usb.
    //por diego katabian

    public GameObject chebolaPrefab;
    public Vector3 desiredSpawnPosition;
    public int screamerID; //cual screamer reproduce este chebola
    public float desiredAura;

    MonsterMovement _mm;

    void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded)
        {
            return;
        }

        Instantiate(chebolaPrefab, desiredSpawnPosition, Quaternion.identity); //hace aparecer al chebola en la posicion

        _mm = chebolaPrefab.GetComponent<MonsterMovement>();
        _mm.desiredScreamer = screamerID; //le cargo el screamer que pedi
        _mm.damageAura = desiredAura;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(desiredSpawnPosition, 2);
    }
}
