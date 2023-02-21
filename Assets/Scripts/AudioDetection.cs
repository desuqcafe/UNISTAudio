using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioDetection : MonoBehaviour
{
    private AudioClip microphoneClip;

    public int sampleWindow = 64; // get data before
    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }



    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
                    // true = loop
                    // 20 = length of audio clip
    }


    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }


    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)    // requires clip input
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)        // calc loudness
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }
}
