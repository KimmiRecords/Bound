using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumPickUpType
{
    //Enumerador Para regular que item levantas y que cantidad de cada uno
    item_usb, item_hp, item_battery, trigger_reja, trigger_grav
}
public class Interactable : MonoBehaviour
{
    public EnumPickUpType pickUpType = EnumPickUpType.item_usb;
    public float amount = 1; 

}
