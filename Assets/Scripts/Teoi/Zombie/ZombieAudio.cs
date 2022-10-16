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
    public EnemySound[] getHitSounds;
    private List<EnemySound[]> _soundLists = new List<EnemySound[]>();

    [SerializeField] const float _soundDelay = 0.5f;

    private EnemySound _currentSoundPlaying;
    private bool _isPlaying = false;

    private IEnumerator coroutine;

    void Awake()
    {
        _soundLists.Add(basicSounds);
        _soundLists.Add(attackSounds);
        _soundLists.Add(diedSounds);
        _soundLists.Add(followingSounds);
        _soundLists.Add(foundedPlayerSounds);
        _soundLists.Add(getHitSounds);

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


    public void PlayRandomSound(EnemySound[] sounds)
    {
        if (!_isPlaying)
        {
            int index = UnityEngine.Random.Range(0, sounds.Length);
            _currentSoundPlaying = sounds[index];
            float soundDuration = _currentSoundPlaying.clip.length;

            coroutine = PlayAndWait(_currentSoundPlaying, soundDuration + _soundDelay);
            StartCoroutine(coroutine);
        }
    }

    //zombieAudio.PlayRandomSound(zombieAudio.attackSounds);
    private IEnumerator PlayAndWait(EnemySound sound, float waitTime)
    {
        _isPlaying = true;
        sound.source.Play();
        yield return new WaitForSeconds(waitTime);
        _isPlaying = false;
    }
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