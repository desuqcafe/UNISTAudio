using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GenerateandPlaySound : MonoBehaviour
{
    public TextMeshProUGUI frequencyText;

    public float duration = 1.0f;
    public int sampleRate = 96000;
    public float volume = 0.5f;
    public int currentFrequency = 0;

    private AudioSource audioSource;

    DisplaySoundInfo displayInfo;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void SetupFile(int frequency)
    {
        Debug.Log("AudioSource: " + audioSource);

        float[] samples = new float[(int)(duration * sampleRate)];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = volume * Mathf.Sin(2 * Mathf.PI * frequency * i / sampleRate);
        }

        AudioClip audioClip = AudioClip.Create("GeneratedWave", samples.Length, 1, sampleRate, false);
        audioClip.SetData(samples, 0);

        audioSource.clip = audioClip;
    }

    public void PlayAudioAtFrequency(int frequency)
    {
        SetupFile(frequency);
        currentFrequency = frequency; // Update the currentFrequency variable
        audioSource.Play();
        frequencyText.text = "Frequency: " + currentFrequency + " Hz";
        Debug.Log("Audio Playing at frequency: " + frequency);
    }

    public void StopAudio()
    {
        audioSource.Stop();
        frequencyText.text = "Frequency: 0" + " Hz";
        Debug.Log("Audio Stopped");
    }

    public void Play1500Hz()
    {
        PlayAudioAtFrequency(1500);
    }

    public void Play10000Hz()
    {
        PlayAudioAtFrequency(10000);
    }

    public void Play18000Hz()
    {
        PlayAudioAtFrequency(20000);
    }
}
