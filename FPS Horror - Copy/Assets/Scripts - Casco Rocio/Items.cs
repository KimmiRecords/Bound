using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int    id;
    public string type;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

}
