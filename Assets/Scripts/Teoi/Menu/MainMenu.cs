using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;
    // Start when the game is iniciated
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        // Plays the song of the main menu, using the AudioManager object
        audioManager.Play("MainMenuTheme");
    }

    // Produce the click sound
    public void ClickSound()
    {
        // Play the click sound
        audioManager.Play("ButtonClick");
    }

    // Change the current scene to the playable game scene
    public void PlayGame ()
    {
        // Stop the Main Menu Theme Sound
        audioManager.Stop("MainMenuTheme");        

        // Play the click sound
        audioManager.Play("ButtonClick");

        // Loads the next level in the queue of scenes
        // Obs: the default scene for the Menu is 1, and for the playable game is 2
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Close the game
    public void QuitGame ()
    {
        Debug.Log("QUIT FUNCTION ENTRY");

        // Play the click sound
        audioManager.Play("ButtonClick");

        // Quit the game
        Application.Quit();
    }

}
