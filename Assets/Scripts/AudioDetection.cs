using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class AudioDetection : MonoBehaviour
{
    private AudioClip microphoneClip;

    public int sampleWindow = 64;
    public int sampleRate = 96000;

    void Start()
    {
        MicrophoneToAudioClip();
    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, sampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }

    public void SaveRecordingLongDuration()
    {
        StartCoroutine(SaveRecordingAfterDelay(20f, "UltrasoundRecording.wav"));
    }

    public IEnumerator SaveRecordingAfterDelay(float delay, string filename)
    {
        yield return new WaitForSeconds(delay);
        SaveRecordingToWavFile(filename);
    }

    public void SaveRecordingToWavFile(string filename)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);
        SavWav.Save(filepath, microphoneClip);
        Debug.Log("Recording saved to: " + filepath);
    }
}
