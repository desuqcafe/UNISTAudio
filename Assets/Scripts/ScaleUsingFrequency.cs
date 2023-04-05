using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUsingFrequency : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioDetection detector;

    public float loudnessSensitivity = 100f;
    public float threshold = 0.1f;
    public float targetFrequency = 19000f; // Set target frequency to 20 kHz

    // Update is called once per frame
    void Update()
    {
        float[] data = new float[8192];
        source.GetSpectrumData(data, 0, FFTWindow.BlackmanHarris);

        float frequency = targetFrequency / (AudioSettings.outputSampleRate / 2f);
        int index = Mathf.RoundToInt((data.Length - 1) * frequency);
        float loudness = data[index] * loudnessSensitivity;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        //lerp from min to max
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
