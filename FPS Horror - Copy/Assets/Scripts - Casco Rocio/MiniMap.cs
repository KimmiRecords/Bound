using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    public GameObject map;
    public bool map1;

    public MapPickedUp obtained;

    private void Start()
    {
        map.SetActive(false);
    }
    private void LateUpdate()
    {
        Vector3 newPosition = player.position;

        newPosition.y = transform.position.y;

        transform.position = newPosition;
    }

    public void MapActived()
    {

        
        if (obtained.obtainedMap == 2)
        {
            map1 = !map1;
            if (map1)
            {
                map.SetActive(true);
            }
            else if (!map1)
            {
                map.SetActive(false);
            }
        }

        
        
    }
}
