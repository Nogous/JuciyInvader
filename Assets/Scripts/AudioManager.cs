﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 1f;
    public bool loop = false;
    public bool startOnPlay = false;
    public bool isSFX = false;
    public bool isBGSound = false;

    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public List<Sound> sounds;
    private List<AudioSource> sources = new List<AudioSource>();


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            Debug.Log(s.name);
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.playOnAwake = false;
            s.source.clip = s.clip;

            s.source.loop = s.loop;

            sources.Add(s.source);

            if (s.startOnPlay)
            {
                s.source.Play();
            }
        }
        UpdateVolume();
    }

    public void UpdateVolume()
    {
        foreach (Sound s in sounds)
        {

            s.source.volume = 0f;
            if (GameManager.instance.SFX && s.isSFX)
            {
                s.source.volume = s.volume;
            }
            if (GameManager.instance.BGSound && s.isBGSound)
            {
                s.source.volume = s.volume;
            }
        }
    }

    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Stop();
                s.source.Play();
                return;
            }
        }
    }
}
