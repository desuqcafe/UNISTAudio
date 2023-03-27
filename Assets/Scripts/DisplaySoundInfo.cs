using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySoundInfo : MonoBehaviour
{
    public GenerateandPlaySound generateAndPlaySound;
    public TextMeshProUGUI frequencyText;
    public TextMeshProUGUI sampleRateText;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (generateAndPlaySound != null)
        {
            frequencyText.text = "Frequency: " + generateAndPlaySound.frequency + " Hz";
            sampleRateText.text = "Sample Rate: " + generateAndPlaySound.sampleRate + " Hz";
        }
    }

}
