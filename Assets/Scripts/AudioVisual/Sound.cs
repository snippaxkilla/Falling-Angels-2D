using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    //settings we want to adjust
    [Range(0,1)]
    public float volume;
    [Range(0, 2)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}
