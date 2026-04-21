using UnityEngine;
using System;
using Unity.Collections;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    //Static Instance so it can be accesed from anywhere
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else {
            DestroyObject(gameObject);
        }
    }
    //Music Starts at same time as game 
    private void Start() {
        PlayMusic("music");
    }

    //Play Music
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();

        }
    }
    //Play SFX
    public void PlaySFX(string name)
    {

        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {

            sfxSource.PlayOneShot(s.clip);


        }

    }

    //Button music and sfx on and off
    public void ToggleMusic() {
        musicSource.mute = !musicSource.mute; 
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    //Slide music and sfx volume

    public void MusicVoulume(float volume) {
        musicSource.volume = volume;
    }

    public void sfxVoulume(float volume)
    {
        sfxSource.volume = volume;
    }
}
