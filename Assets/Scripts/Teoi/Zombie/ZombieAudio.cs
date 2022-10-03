using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using System;

public class ZombieAudio : MonoBehaviour
{
    public EnemySound[] basicSounds;
    public EnemySound[] attackSounds;
    public EnemySound[] diedSounds;
    public EnemySound[] followingSounds;
    public EnemySound[] foundedPlayerSounds;
    private List<EnemySound[]> _soundLists = new List<EnemySound[]>();

    void Awake()
    {
        _soundLists.Add(basicSounds);
        _soundLists.Add(attackSounds);
        _soundLists.Add(diedSounds);
        _soundLists.Add(followingSounds);
        _soundLists.Add(foundedPlayerSounds);

        foreach (EnemySound[] list in _soundLists)
        {
            Debug.Log(list);
            foreach (EnemySound s in list)
            {
                Debug.Log(s);
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.outputAudioMixerGroup = s.output;

                s.source.loop = s.loop;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.spatialBlend = s.spatialBlend;
            }
        }
    }

    // OBS: The functions bellow could be one function with a "switch - case"
    //      

    // Play the sound with the 'name' passed by parameter
    public void Play(string name, EnemySound[] sounds)
    {
        // search in the sound array the sound with de given name
        EnemySound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to PLAY!");
            return;
        }
        Debug.LogWarning("Sound:" + name + "");

        // Play the sound found
        s.source.Play();
    }

    // Stop the sound with the 'name' passed by parameter
    public void Stop(string name, EnemySound[] sounds)
    {
        // search in the sound array the sound with de given name
        EnemySound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to STOP!");
            return;
        }

        // Stop the sound found
        s.source.Stop();
    }

    // Stop the sound with the 'name' passed by parameter
    public void Pause(string name, EnemySound[] sounds)
    {
        // search in the sound array the sound with de given name
        EnemySound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to PAUSE!");
            return;
        }

        // Test if the audio is playing
        if (s.source.isPlaying)
            s.source.Pause();
    }

    // Stop the sound with the 'name' passed by parameter
    public void Unpause(string name, EnemySound[] sounds)
    {
        // search in the sound array the sound with de given name
        EnemySound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to UNPAUSE!");
            return;
        }

        // Test if the audio is not playing
        if (s.source.isPlaying == false)
            s.source.UnPause();
    }

    // Return the audioclip of the given name
    public AudioClip ReturnAudioclip(string name, EnemySound[] sounds)
    {
        EnemySound s = Array.Find(sounds, sound => sound.name == name);

        return s.clip;
    }

    /*
    // Can play multiple sounds on one AudioSource
    public void PlayOneShot(string name, float volumeScale)
    {
        // search in the sound array the sound with de given name
        EnemySound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found to PlayOneShot!");
            return;
        }

        s.source.PlayOneShot();
    }


    */

    public void PlayRandomSound(EnemySound[] sounds)
    {
        int index = UnityEngine.Random.Range(0, sounds.Length);
        sounds[index].source.Play();
    }
}
