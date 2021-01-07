using System.Collections;
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
            s.source.volume = s.volume;
            s.source.loop = s.loop;

            sources.Add(s.source);

            if (s.startOnPlay)
            {
                s.source.Play();
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
