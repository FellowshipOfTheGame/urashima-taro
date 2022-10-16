using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Awake()
    {
        SetVolume(PlayerPrefs.GetFloat("main-volume", 0));
        SetMusicVolume(PlayerPrefs.GetFloat("music-volume", 0));
        SetEffectsVolume(PlayerPrefs.GetFloat("effects-volume", 0));
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("main-volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("main-volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("music-volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("music-volume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("effects-volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("effects-volume", volume);
    }
}
