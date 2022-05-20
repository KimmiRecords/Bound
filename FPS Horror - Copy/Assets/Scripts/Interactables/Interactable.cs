using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumPickUpType
{
    item_usb, item_battery, solo_infoPopup, item_flashlight, trigger_button
}
public class Interactable : MonoBehaviour
{
    public EnumPickUpType pickUpType = EnumPickUpType.item_usb; //esto solo determina cual aparece x default en inspector. hay que ir a setearlo igual.
    public bool muestraManito = true;

    public virtual void Interact() //la base. todos los pickups hacen esto cuando los interactuas con E.
    {
        //print("llamé al Interact de " + this.gameObject);

        if (this.pickUpType != EnumPickUpType.solo_infoPopup) //si no es solo informativo, hace ruidito
        {
            AudioManager.instance.PlayPickup(1.1f);
            //print("reproduje el pickup sfx");
        }
    }
}
