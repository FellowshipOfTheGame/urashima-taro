using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;

    // Receive the PauseMenu game object
    public GameObject pauseMenuUI;
    public GameObject volumePanel;

    public TMP_Text menuLabelText;

    //private AudioManager audioManager;

    private void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        Resume();
    }


    // Update is called once per frame
    void Update()
    {
        // Check if the user press ESC button
        if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            Debug.Log("PRESSED ESC");
            Debug.Log(isGamePaused);
            SwitchPaused();
        }
    }
    public void SwitchPaused()
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
    // Exit the Pause Menu
    public void Resume()
    {
        //audioManager.Play("Button");
        // Exit the Pause Menu in the canvas
        pauseMenuUI.SetActive(false);

        // Unfreeze the game
        Time.timeScale = 1f;

        // Set false meaning that the game is NOT paused
        isGamePaused = false;
    }

    // Open the Pause Menu
    public void Pause()
    {
        //audioManager.Play("Button");

        menuLabelText.text = "PAUSADO";
        // Show the Pause Menu in the canvas
        pauseMenuUI.SetActive(true);

        // Freeze the game
        Time.timeScale = 0f;

        // Set true meaning that the game is paused
        isGamePaused = true;

        //BackgroundImage.SetActive(true);
    }

    public void ReloadScene()
    {
        // StartCoroutine(FinishAndLoadSceneEnumerator(SceneManager.GetActiveScene().buildIndex));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Quit the game
    public void QuitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }

    private float effecttmp;
    
    public void Volume()
    {
        //audioManager.Play("Button");

        menuLabelText.text = "VOLUME";
                        
        volumePanel.SetActive(true);
    }
    
    float Remap(float value, float min1, float max1, float min2, float max2) 
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
    }
}
