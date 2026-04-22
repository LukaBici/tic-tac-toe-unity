using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private bool musicMuted;
    private bool sfxMuted;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadSettings();
        ApplySettings();
        PlayMusic("music");
    }

    // ---------- PLAY ----------
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music Not Found: " + name);
            return;
        }

        musicSource.clip = s.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX Not Found: " + name);
            return;
        }

        sfxSource.PlayOneShot(s.clip);
    }

    // ---------- TOGGLES ----------
    public void ToggleMusic()
    {
        musicMuted = !musicMuted;
        ApplyMusic();

        PlayerPrefs.SetInt("MusicMute", musicMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ToggleSFX()
    {
        sfxMuted = !sfxMuted;
        ApplySFX();

        PlayerPrefs.SetInt("SFXMute", sfxMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // ---------- VOLUME ----------
    public void MusicVolume(float volume)
    {
        musicVolume = volume;
        ApplyMusic();

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void SFXVolume(float volume)
    {
        sfxVolume = volume;
        ApplySFX();

        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }

    // ---------- APPLY ----------
    private void ApplySettings()
    {
        ApplyMusic();
        ApplySFX();
    }

    private void ApplyMusic()
    {
        musicSource.mute = musicMuted;
        musicSource.volume = musicVolume;
    }

    private void ApplySFX()
    {
        sfxSource.mute = sfxMuted;
        sfxSource.volume = sfxVolume;
    }

    // ---------- LOAD ----------
    private void LoadSettings()
    {
        musicMuted = PlayerPrefs.GetInt("MusicMute", 0) == 1;
        sfxMuted = PlayerPrefs.GetInt("SFXMute", 0) == 1;

        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }
}