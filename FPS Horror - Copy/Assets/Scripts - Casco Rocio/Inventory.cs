using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject slotHalder;
    private int _allSlots;
    private int _enabledSlots;
    private GameObject[] _slot;


    void Start()
    {
        //_allSlots = slotHalder.transform.childCount;
        //_slot = new GameObject[_allSlots];

        //for (int i = 0; i < _allSlots; i++)
        //{
        //    _slot[i] = slotHalder.transform.GetChild(i).gameObject;
        //}
        Count();
    }

    public void Count()
    {
        _allSlots = slotHalder.transform.childCount;
        _slot = new GameObject[_allSlots];

        for (int i = 0; i < _allSlots; i++)
        {
            _slot[i] = slotHalder.transform.GetChild(i).gameObject;

            if (_slot[i].GetComponent<Slots>().item == null)
            {
                _slot[i].GetComponent<Slots>().empty = true;
            }
        }
    }

    public void InventoryOpen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;


            if (inventoryEnabled)
            {
                AudioManager.instance.PlayInventoryOpen();
                inventory.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None; // puedo mover el cursor
                Time.timeScale = 0;
            }
            else
            {
                AudioManager.instance.PlayInventoryClose();
                inventory.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void AddItem(GameObject itemObject, int itemId, string itemType, Sprite itemIcon) 
    {
        for (int i = 0; i < _allSlots; i++)
        {
            if (_slot[i].GetComponent<Slots>().empty)
            {
                itemObject.GetComponent<Items>().pickedUp = true;

                _slot[i].GetComponent<Slots>().item = itemObject;
                _slot[i].GetComponent<Slots>().id = itemId;
                _slot[i].GetComponent<Slots>().type = itemType;
                _slot[i].GetComponent<Slots>().icon = itemIcon;

                itemObject.transform.parent = _slot[i].transform;

                itemObject.SetActive(false);

                _slot[i].GetComponent<Slots>().UpdateSlot();

                _slot[i].GetComponent<Slots>().empty = false;

                return;
            }
        }
    
    }
}
