using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPopupOneTime : InfoPopup
{
    public override void Hide()
    {
        subsCanvasText.text = "";
        Destroy(this.gameObject);
    }
}
