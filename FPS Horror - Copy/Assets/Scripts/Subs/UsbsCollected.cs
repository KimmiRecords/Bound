using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsbsCollected : MonoBehaviour
{
    private Text usbsCollectedText;

    public string FirstPartOfText;

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
        amount = PlayerStats.usbsCollected.ToString();
        usbsCollectedText.text = FirstPartOfText + amount;
    }
}
