using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public GameObject item;
    public int id;
    public string type;
    public Sprite icon;

    public bool empty;

    public RectTransform slotIconGameObject;
    
    public void UpdateSlot()
    {
        slotIconGameObject = (RectTransform)this.gameObject.transform.GetChild(0);
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

    
}
