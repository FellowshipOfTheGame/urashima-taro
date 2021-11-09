using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSanity : MonoBehaviour
{
    public Slider sanitySlider;
    private HealthManager healthManager;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        GetHealthmanagerSanity();
    }

    // Update is called once per frame
    void Update()
    {
        // temp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.UpdateCurrentSanity(-5);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            this.UpdateCurrentSanity(5);
        }
    }
    public void UpdateMaxSanity(int sanityAddiction)
    {
        int updatedMaxSanity = healthManager.maxSanity + sanityAddiction;
        sanitySlider.maxValue = updatedMaxSanity;
        healthManager.maxSanity = updatedMaxSanity;
    }

    private void GetHealthmanagerSanity()
    {
        sanitySlider.maxValue = healthManager.maxSanity;
        sanitySlider.value = healthManager.currentSanity;
    }

    // Set the current sanity with the max sanity
    public void SetMaxSanity()
    {
        sanitySlider.value = healthManager.maxSanity;
        healthManager.currentSanity = healthManager.maxSanity;
    }

    // Change current sanity (player bar and HeathManager) with adding (negative or positive) value in the current sanity
    public void UpdateCurrentSanity(int sanityAddition)
    {
        int updatedSanity = healthManager.currentSanity + sanityAddition;

        if (updatedSanity <= 0)
        {
            // CALL FUNCION OF DEATH OF THE PLAYER BY LIFE
            Debug.Log("PLAYER DIED BY SANITY");
            healthManager.currentSanity = 0;
            sanitySlider.value = 0;
        }
        // Test if the current sanity exceded the maximum sanity value
        else if (updatedSanity > sanitySlider.maxValue)
        {
            Debug.Log("PLAYER MAX SANITY");
            this.SetMaxSanity();
        }
        else
        {
            sanitySlider.value = updatedSanity;
            healthManager.currentSanity = updatedSanity;
        }
    }

    // Test if the player get Sanity to zero (died or got crazy, we don't know yet)
    private bool isSanityEnded()
    {
        if (healthManager.currentSanity <= 0)
        {
            return true;
        }
        return false;
    }
}
