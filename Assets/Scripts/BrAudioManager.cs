using UnityEngine.Audio;
using System;
using UnityEngine;

public class BrAudioManager : MonoBehaviour
{
    public Sound[] sounds;
    string[] notes;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    private void Start()
    {
        notes =new string[8]{ "do","re","mi","fa","so","la","si","doe" };
    }
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        
    }

    public string GetAudio(int index)
    {
        return notes[index];
    }
}
