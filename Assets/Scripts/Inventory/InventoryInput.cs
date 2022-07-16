using UnityEngine;
using UnityEngine.InputSystem;

// Script used to get the player key to open or close the inventory
// OBS: the key from the keyboard to open or close is 'i'
public class InventoryInput : MonoBehaviour
{
    public GameObject inventory;
    public GameObject OpenButton;
    public GameObject CloseButton;
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

    public void OpenOrCloseInventory(bool activeSelf)
    {
        inventory.SetActive(activeSelf);
        OpenButton.SetActive(!OpenButton.activeSelf);
        CloseButton.SetActive(!CloseButton.activeSelf);
    }
}


