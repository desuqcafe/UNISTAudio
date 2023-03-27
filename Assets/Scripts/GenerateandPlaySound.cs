using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateandPlaySound : MonoBehaviour
{

    public float duration = 1.0f;
    public int sampleRate = 96000;
    public int frequency = 20000;   // Usually above 20,000 means generate ultrasound wave
    public float volume = 0.5f;

    private bool isButtonClicked = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        float[] samples = new float[(int)(duration * sampleRate)];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = volume * Mathf.Sin(2 * Mathf.PI * frequency * i / sampleRate);
        }

        AudioClip audioClip = AudioClip.Create("UltrasoundWave", samples.Length, 1, sampleRate, false);
        audioClip.SetData(samples, 0);

        audioSource.clip = audioClip;
        audioSource.Play();

    }

}
