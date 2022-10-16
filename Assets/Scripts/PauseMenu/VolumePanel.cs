using UnityEngine;
using UnityEngine.UI;

public class VolumePanel : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider, effectsVolumeSlider, musicVolumeSlider;

    private void Start()
    {
        var audioMixer = FindObjectOfType<SettingsMenu>().audioMixer;

        audioMixer.GetFloat("main-volume", out var masterValue);
        masterVolumeSlider.value = Mathf.Pow(10, masterValue / 20);
        audioMixer.GetFloat("effects-volume", out var effectsValue);
        effectsVolumeSlider.value = Mathf.Pow(10, effectsValue / 20);

        audioMixer.GetFloat("music-volume", out var musicValue);
        musicVolumeSlider.value = Mathf.Pow(10, musicValue / 20);
    }
}
