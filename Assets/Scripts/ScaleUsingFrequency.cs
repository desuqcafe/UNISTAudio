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
    public float targetFrequency = 8000f; // Set target frequency to 20 kHz

    // Update is called once per frame
    void Update()
    {
        float[] data = new float[8192];
        source.GetSpectrumData(data, 0, FFTWindow.BlackmanHarris);

        int sampleRate = AudioSettings.outputSampleRate;
        float hertzPerBin = (float)sampleRate / 2f / data.Length; // Calculate the frequency interval per bin
        int index = Mathf.RoundToInt(targetFrequency / hertzPerBin); // Calculate the index of the target frequency

        if (index < 0) index = 0;
        if (index >= data.Length) index = data.Length - 1;

        float loudness = data[index] * loudnessSensitivity;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        // Lerp from min to max
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
