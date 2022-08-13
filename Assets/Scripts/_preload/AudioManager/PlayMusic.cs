using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public enum MusicType { MenuTheme, PlayTheme };
    public MusicType music;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (music == MusicType.PlayTheme)
        {
            audioManager.Play(music.ToString());

        }
        else
        {
            audioManager.Play(music.ToString());
        }
    }

    void PlayThemeIntro()
    {
        audioManager.Play(music.ToString("PlayThemeLoop"));
    }
}
