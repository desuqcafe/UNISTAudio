using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateandPlaySound : MonoBehaviour
{

    public float duration = 1.0f;
    public int sampleRate = 44100;
    public int frequency = 440;
    public float volume = 0.5f;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // gen random sound clip
        float[] samples = new float[(int)(duration * sampleRate)];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = volume * Random.Range(-1.0f, 1.0f);
        }

        // create clip
        AudioClip audioClip = AudioClip.Create("RandomSoundClip", samples.Length, 1, sampleRate, false);
        audioClip.SetData(samples, 0);

        // play clip
        audioSource.clip = audioClip;
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
