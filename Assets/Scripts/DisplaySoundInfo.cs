using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySoundInfo : MonoBehaviour
{
    public GenerateandPlaySound generateAndPlaySound;
    public AudioDetection audioDetection;
    public TextMeshProUGUI sampleRateText;
    public TextMeshProUGUI microphoneText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        string microphoneName = Microphone.devices[0];

        if (generateAndPlaySound != null)
        {
            sampleRateText.text = "Sample Rate: " + generateAndPlaySound.sampleRate + " Hz";
            microphoneText.text = "Microphone: " + microphoneName;
        }
    }

}
