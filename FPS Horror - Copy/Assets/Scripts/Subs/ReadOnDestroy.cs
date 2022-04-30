using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadOnDestroy : Subs
{
    public GameObject dialogueTriggerPrefab;

    private Vector3 _playerPos;
    void Start()
    {
    }

    void Update()
    {
        _playerPos = PlayerStats.playerTransform.position;

    }

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) //esto es clave. solo va a reproducir si la escena esta activa. asi, si cierro la escena y se destruye todo, no reproduce nada.
        {
            return;
        }


        //Show(desiredText, desiredTime);
    }
}
