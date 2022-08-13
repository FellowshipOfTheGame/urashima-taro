using UnityEngine;
using UnityEngine.InputSystem;

// Script used to get the player key to open or close the inventoryMenu
// OBS: the key from the keyboard to open or close is 'i'
public class InventoryInput : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject OpenButton;
    public GameObject CloseButton;

    private bool isGamePaused = false;

    void Update()
    {
        // WARNING: for some reason pressing "I" freezes the player movement
        // probably because the old input system uses "I" to do something
        /*
        // Check if the key to set active the inventoryMenu is pressed
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            // If the inventoryMenu is active (activeSelf == true) set false
            // else, set true
            OpenOrCloseInventory(!inventoryMenu.activeSelf);
        }
        */
    }

    // Function to set the inventoryMenu gameobject active or disabled
    // Also inverts the 'activeness' of the buttons to close and open the inventoryMenu
    public void OpenOrCloseInventory(bool activeSelf)
    {
        inventoryMenu.SetActive(activeSelf);
        OpenButton.SetActive(!OpenButton.activeSelf);
        CloseButton.SetActive(!CloseButton.activeSelf);
        GamePause();
    }

    private void GamePause()
    {
        if (isGamePaused)
        {
            isGamePaused = false;
            Time.timeScale = 1;
        }
        else
        {
            isGamePaused = true;
            Time.timeScale = 0;
        }
    }
}


