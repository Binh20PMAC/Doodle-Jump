using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Audio[] musicAudio, sfxAudio;
    public AudioSource musicSource, sfxSource;

    [SerializeField]
    private GameObject TurnOn;
    [SerializeField]
    private GameObject TurnOnPause;

    private void Start()
    {
        if (PlayerPrefs.GetInt("SFXMute") == 1)
        {
            sfxSource.mute = true;
            TurnOn.SetActive(false);
            TurnOnPause.SetActive(false);
        }
        else
        {
            sfxSource.mute = false;

            TurnOn.SetActive(true);
            TurnOnPause.SetActive(true);
        }
    }
    private void Awake()
    {

        instance = this;

    }

    public void PlayMusic(string name)
    {
        Audio s = Array.Find(musicAudio, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {

        Audio s = Array.Find(sfxAudio, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        if (sfxSource.mute)
        {
            PlayerPrefs.SetInt("SFXMute", 1);
            TurnOn.SetActive(false);
            TurnOnPause.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("SFXMute", 0);
            TurnOn.SetActive(true);
            TurnOnPause.SetActive(true);
        }
    }
}
