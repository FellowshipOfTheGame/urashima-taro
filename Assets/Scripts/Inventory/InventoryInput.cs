using UnityEngine;
using UnityEngine.InputSystem;

// Script used to get the player key to open or close the inventory
// OBS: the key from the keyboard to open or close is 'i'
public class InventoryInput : MonoBehaviour
{
    public GameObject inventory;
    public GameObject OpenButton;
    public GameObject CloseButton;

    private bool isGamePaused = false;
    void Update()
    {
        // Check if the key to set active the inventory is pressed
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            // If the inventory is active (activeSelf == true) set false
            // else, set true
            OpenOrCloseInventory(!inventory.activeSelf);
        }
    }

    // Function to set the inventory gameobject active or disabled
    // Also inverts the 'activeness' of the buttons to close and open the inventory
    public void OpenOrCloseInventory(bool activeSelf)
    {
        inventory.SetActive(activeSelf);
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


