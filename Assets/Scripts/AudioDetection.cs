using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
//using UnityEngine.Audio;


public class AudioDetection : MonoBehaviour
{
    private AudioClip microphoneClip;
    public string microphoneName;
    public TextMeshProUGUI saveLocation;



    public int sampleWindow = 64;
    public int sampleRate = 96000;

    void Start()
    {
        microphoneName = Microphone.devices[0];
        MicrophoneToAudioClip();
    }

    public void MicrophoneToAudioClip()
    {        
        Debug.Log("Microphone: " + microphoneName);
        //Debug.Log("Speaker mode: " + AudioSettings.speakerMode);

        microphoneClip = Microphone.Start(microphoneName, true, 10, sampleRate);  // 10 sec
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
        StartCoroutine(SaveRecordingAfterDelay(10f, "UltrasoundRecording.wav"));
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
        saveLocation.text = filepath;
    }
}
