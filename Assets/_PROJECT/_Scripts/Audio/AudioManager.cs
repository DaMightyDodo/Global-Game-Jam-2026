using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Music")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip mainTheme;

    [Header("SFX")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private SoundEntry[] sfxEntries;

    private Dictionary<string, SoundEntry> _sfxLookup;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        BuildSfxLookup();
        PlayMainTheme();
    }

    private void BuildSfxLookup()
    {
        _sfxLookup = new Dictionary<string, SoundEntry>();

        foreach (var entry in sfxEntries)
        {
            if (entry == null || entry.clip == null)
                continue;

            if (_sfxLookup.ContainsKey(entry.id))
            {
                Debug.LogWarning($"[SoundManager] Duplicate SFX id: {entry.id}");
                continue;
            }

            _sfxLookup.Add(entry.id, entry);
        }
    }

    private void PlayMainTheme()
    {
        if (musicSource == null || mainTheme == null)
            return;
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicSource.clip = mainTheme;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(string id)
    {
        if (!_sfxLookup.TryGetValue(id, out var entry))
        {
            Debug.LogWarning($"[SoundManager] SFX not found: {id}");
            return;
        }

        float pitch = Random.Range(entry.minPitch, entry.maxPitch);
        float volume = Random.Range(entry.minVolume, entry.maxVolume);

        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(entry.clip, volume);
        sfxSource.pitch = 1f;
    }
}