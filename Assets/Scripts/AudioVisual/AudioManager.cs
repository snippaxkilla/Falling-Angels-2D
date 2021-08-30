using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool IsGlobal;
    //make an list for all the sounds
    public Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
           Destroy(gameObject);
           return;
        }

        if (IsGlobal)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        if (IsGlobal)
        {
            Loop("Theme");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        if (s == null)
            return;
        }

    public void Loop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        s.source.loop = true;
    }
}
