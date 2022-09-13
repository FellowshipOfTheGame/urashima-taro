using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public enum MusicType { MenuTheme, PlayTheme };
    public MusicType music;
    private AudioManager audioManager;

    private IEnumerator coroutine;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        
        if (music == MusicType.PlayTheme)
        {
            float clipLength = audioManager.ReturnAudioclip("PlayTheme").length;
            coroutine = WaitAndPlayIntro(clipLength);
            audioManager.Play(music.ToString());
            StartCoroutine(coroutine);
            Debug.Log("ENTROU PLAYTHEME");
        }
        else
        {
            audioManager.Play(music.ToString());
        }
        
    }

    private IEnumerator WaitAndPlayIntro(float clipLength)
    {
        Debug.Log("ENTROU WAIT");
        yield return new WaitForSeconds(clipLength);
        audioManager.Play("PlayThemeLoop");
        Debug.Log("SAIU WAIT");
    }
}
