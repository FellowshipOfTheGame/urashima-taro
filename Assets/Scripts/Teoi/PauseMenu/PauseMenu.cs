using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    // Receive the PauseMenu game object
    public GameObject pauseMenuUI;
    public GameObject BackgroundImage;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the user press ESC button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // IF the game is already paused, exits the pause menu
            if (isGamePaused)
            {
                Resume();
            } 
            // ELSE join the pause menu
            else
            {
                Pause();
            }
        }
    }

    // Exit the Pause Menu
    public void Resume()
    {
        // Play the click sound
        audioManager.Play("ButtonClick");

        // Exit the Pause Menu in the canvas
        pauseMenuUI.SetActive(false);
        BackgroundImage.SetActive(false);

        // Unfreeze the game
        Time.timeScale = 1f;

        // Set false meaning that the game is NOT paused
        isGamePaused = false;
    }

    // Open the Pause Menu
    void Pause()
    {
        // Play the click sound
        audioManager.Play("ButtonClick");

        // Show the Pause Menu in the canvas
        pauseMenuUI.SetActive(true);

        // Freeze the game
        Time.timeScale = 0f;

        // Set true meaning that the game is paused
        isGamePaused = true;

        BackgroundImage.SetActive(true);
    }

    // Open the Main Menu
    public void LoadMenu()
    {
        // Play the click sound
        audioManager.Play("ButtonClick");

        // Stop the Play Scene Theme Song
        audioManager.Stop("PlayTheme0");

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    // Quit the game
    public void QuitGame()
    {
        // Play the click sound
        audioManager.Play("ButtonClick");

        Debug.Log("Quit the game");
        Application.Quit();
    }
}
