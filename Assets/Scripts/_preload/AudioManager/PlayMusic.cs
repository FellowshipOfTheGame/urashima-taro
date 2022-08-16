using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public enum MusicType { MenuTheme, PlayTheme };
    public MusicType music;
    private AudioManager audioManager;
    private AudioClip clip;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (music == MusicType.PlayTheme)
        {
            clip = audioManager.ReturnAudioclip("PlayTheme");
            Invoke("PlayThemeIntro", clip.length);
            audioManager.Play(music.ToString());
            
        }
        else
        {
            audioManager.Play(music.ToString());
        }
    }

    void PlayThemeIntro()
    {
        Debug.Log("TOCOU");
        audioManager.Play("PlayThemeLoop");
    }
}
