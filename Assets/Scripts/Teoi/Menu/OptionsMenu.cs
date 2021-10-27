using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public GameObject toggleBar01;
    public GameObject toggleBar02;

    Resolution[] resolutions;
    private List<int> resolutionsIndex = new List<int>();

    // Play when the game starts
    void Start ()
    {
        // Keep the resolutions available for the current user machine
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> resolutionList = new List<string>();

        int currentResolutionIndex = 0;

        // Add the first resolution from the resolution list
        resolutionList.Add(resolutions[0].width + " x " + resolutions[0].height);
        resolutionsIndex.Add(0);

        // Transforms the resolution list in a list of strings 
        // for the resolutionDropdown formatation
        for (int i = 1; i < resolutions.Length; i++)
        {
            // Test if the resolution of index 'i' is not equal the resolution of index 'i-1' ( Prevents duplicate resolutions on the toggle )
            if (!(resolutions[i].width == resolutions[i - 1].width && resolutions[i].height == resolutions[i - 1].height))
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;

                resolutionList.Add(option);
                resolutionsIndex.Add(i);
            }

            // Search for the index of the current screen resolution and
            // keeps his value in the variable 'currentResolutionIndex'
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Add the user resolution list in the resolution dropdown in the MainMenu
        resolutionDropdown.AddOptions(resolutionList);

        // Add the current resolution in the dropdown default value
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void UpdateResolutionList()
    {

    }

    // Set the resolution of the game
    public void SetResolution (int toggleIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionsIndex[toggleIndex]];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Set the volume of the game
    public void SetVolume (float volume)
    {
        // "volume" is the exposed script parameter for the Master Volume of the game
        audioMixer.SetFloat("volume", volume);
    }

    // Set the graphic quality of the game
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Set the screen in fullScreen or not in fullScreen
    public void SetScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        // Invert the toggle image
        toggleBar01.SetActive(!toggleBar01.activeSelf);
        toggleBar02.SetActive(!toggleBar02.activeSelf);
    }
}
