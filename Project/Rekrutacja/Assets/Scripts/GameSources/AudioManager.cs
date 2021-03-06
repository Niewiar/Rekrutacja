using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mainMixer;
    public Sound[] sounds;

    void Awake()
    {
        Cursor.visible = false;

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.valume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        mainMixer.SetFloat("Volume", PlayerPrefs.GetFloat("volumeMain"));

        Play("Music");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Nie ma takiego dźwięku jak: " + name);
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Nie ma takiego dźwięku jak: " + name);
            return;
        }
        s.source.Stop();
    }
}
