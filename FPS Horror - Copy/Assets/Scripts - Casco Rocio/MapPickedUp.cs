using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickedUp : Interactable
{
    public Inventory _inventory;

    [HideInInspector]
    public int obtainedMap = 1;

    public override void Interact()
    {
        _inventory.GetComponent<Inventory>().InventoryOpen();
        
        if (gameObject != null)
        {
            GameObject itemPickedUp = gameObject.transform.gameObject;
            Items item = itemPickedUp.GetComponent<Items>();
            _inventory.AddItem(itemPickedUp, item.id, item.type, item.icon);
        }
        obtainedMap += obtainedMap;
        base.Interact();
        
    }
}
