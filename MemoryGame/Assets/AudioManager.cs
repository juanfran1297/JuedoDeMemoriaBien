using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Fondo");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sonido: " + name + "no se ha encontrado!!");
            return;
        }
        s.audioSource.Play();
    }

    public void BajarVolumen(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sonido: " + name + "no se ha encontrado!!");
            return;
        }
        s.audioSource.volume = 0f;
    }

    public void SubirVolumen(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sonido: " + name + "no se ha encontrado!!");
            return;
        }
        s.audioSource.volume = s.volume;
    }

    public void CambiarClip(string name, AudioClip nuevoClip)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sonido: " + name + "no se ha encontrado!!");
            return;
        }
        s.audioSource.clip = nuevoClip;
    }
}
