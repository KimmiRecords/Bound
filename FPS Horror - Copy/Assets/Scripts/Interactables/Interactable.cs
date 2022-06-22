using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumPickUpType
{
    item_usb, item_battery, solo_infoPopup, item_flashlight, trigger_button, item_cardkey, item_map //solo agrege item_map. Casco Rocio
}
public abstract class Interactable : MonoBehaviour
{
    //los interactables tienen pickuptype, y hacen mostrar una manito (ui)
    //si son collectables van a aparecer en el inventario y destruirse
    //TP2 - Francisco Serra, Rocio Casco y Diego Katabian

    public EnumPickUpType pickUpType = EnumPickUpType.item_usb; //esto solo determina cual aparece x default en inspector. hay que ir a setearlo igual.
    public bool muestraManito = true;
    public Inventory inventory;

    private void Start()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }
    }
    public virtual void Interact() //la base. todos los pickups hacen esto cuando los interactuas con E.
    {
        if (this.pickUpType != EnumPickUpType.solo_infoPopup) //si no es solo informativo, hace ruidito
        {
            AudioManager.instance.PlayPickup(1.1f);
        }
    }
}
