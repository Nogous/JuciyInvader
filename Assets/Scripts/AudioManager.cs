using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    public string name;
    public AudioClip clip;
    public float volume = 1f;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public List<Sound> sounds;

    public AudioSource source;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                source.Stop();
                source.clip = s.clip;
                source.volume = s.volume;
                source.Play();
            }
        }
    }
}
