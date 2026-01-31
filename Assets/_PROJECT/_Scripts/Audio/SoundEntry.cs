using UnityEngine;

[System.Serializable]
public class SoundEntry
{
    public string id;
    public AudioClip clip;

    [Header("Variation")]
    [Range(0.5f, 2f)] public float minPitch = 0.95f;
    [Range(0.5f, 2f)] public float maxPitch = 1.05f;

    [Range(0f, 1f)] public float minVolume = 0.9f;
    [Range(0f, 1f)] public float maxVolume = 1f;
}