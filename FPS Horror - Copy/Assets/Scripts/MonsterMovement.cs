using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public static MonsterMovement instance;

    public float timer;
    public Transform playerTransform;
    public Vector3 playerPosition;
    public Vector3 vectorToPlayer;
    public float distanceToPlayer;
    public float damageAura; //el radio del aura
    public static float monsterSpeed = 0.25f;

    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        playerPosition = playerTransform.position; //actualiza la posicion del jugador

        vectorToPlayer = playerPosition - transform.position; // calculo la distancia al player
        distanceToPlayer = vectorToPlayer.magnitude;

        if (Input.GetKeyDown(KeyCode.P)) //toco P para tpear al monstruo behind you
        {
            TPBehindYou(damageAura);
        }

        if (distanceToPlayer <= damageAura && distanceToPlayer > 0.5f) //si estoy cerca, lo entro a seguir
        {
            transform.position += vectorToPlayer * monsterSpeed * Time.deltaTime;

            PlayerStats.playerHp -= 0.1f; //daña al player constantemente (como un aura de daño)
            //print("Ahora le queda " + PlayerStats.playerHp + " de vida");

        }

    }

    void TPBehindYou(float distance)
    {
        transform.position = playerPosition + (playerTransform.forward * -distance); //teleports behind you
        //print("El enemigo tpeo a la posicion " + transform.position);

    }

    public void TPToPosition(Vector3 position)
    {
        transform.position = position; //teleports a la posicion pedida
        print("El enemigo tpeo a la posicion " + transform.position);

    }
}
