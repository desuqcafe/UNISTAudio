using UnityEngine;


public class ScaleFromAudio : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioDetection detector;

    public float loudnessSensitivity = 100f;
    public float threshold = 0.1f;

    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensitivity;

        if (loudness < threshold)
        {
            loudness = 0;
        }
        //lerp from min to max
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}