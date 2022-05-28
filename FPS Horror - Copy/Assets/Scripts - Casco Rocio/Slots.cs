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


    //public Slots(GameObject items, int ids, string types, Sprite icons, bool emptys)
    //{
    //    item  = items;
    //    id    = ids;
    //    type  = types;
    //    icon  = icons;
    //    empty = emptys;



    //}
    private void Awake()
    {
    }
    //private void Start()
    //{
    //    slotIconGameObject = (RectTransform)this.gameObject.transform.GetChild(0);
    //}
    public void UpdateSlot()
    {
        slotIconGameObject = (RectTransform)this.gameObject.transform.GetChild(0);
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

    
}
