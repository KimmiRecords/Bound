using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsbsCollected : MonoBehaviour
{
    //este script actualiza la cantidad de usbs recolectados en el canvas
    //por diego katabian

    public string FirstPartOfText;
    private Text usbsCollectedText;
    private string amount;

    void Start()
    {
        if (GetComponent<Text>() != null)
        {
            usbsCollectedText = GetComponent<Text>();
        }
    }

    void Update()
    {
        if (PlayerStats.instance.UsbsCollected != 0)
        {
            amount = PlayerStats.instance.UsbsCollected.ToString() + "/4";
            usbsCollectedText.text = FirstPartOfText + amount;
        }
    }
}
