using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsbsCollected : MonoBehaviour
{
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
        if (PlayerStats.UsbsCollected != 0)
        {
            amount = PlayerStats.UsbsCollected.ToString();
            usbsCollectedText.text = FirstPartOfText + amount;
        }
    }
}
