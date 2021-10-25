using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Slider lifeSlider;
    private HealthManager healthManager;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        SetHeathmanagerStatus();
    }

    void Update()
    {
        // temp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.UpdateCurrentLife(-5);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            this.UpdateCurrentLife(5);
        }
    }

    // Set the life bar with the current status of the life manager
    private void SetHeathmanagerStatus()
    {
        lifeSlider.maxValue = healthManager.maxLife;
        lifeSlider.value = healthManager.currentLife;
    }

    // Change the max of the life slider and healthManager, meaning that the maximum life of the player has changed
    public void UpdateMaxLife(int lifeAddiction)
    {
        int updatedMaxLife = healthManager.maxLife + lifeAddiction;
        lifeSlider.maxValue = updatedMaxLife;
        healthManager.maxLife = updatedMaxLife;
    }
    
    // Set the current life with the max life
    public void SetMaxLife ()
    {
        lifeSlider.value = healthManager.maxLife;
        healthManager.currentLife = healthManager.maxLife;
    }

    // Change current life (player bar and HeathManager) with adding (negative or positive) value in the current life
    public void UpdateCurrentLife(int lifeAddition)
    {
        int updatedLife = healthManager.currentLife + lifeAddition;
        
        if (updatedLife <= 0)
        {
            // CALL FUNCION OF DEATH OF THE PLAYER BY LIFE
            Debug.Log("PLAYER DIED");
            healthManager.currentLife = 0;
            lifeSlider.value = 0;
        }
        // Test if the current life exceded the maximum life value
        else if (updatedLife > lifeSlider.maxValue)
        {
            Debug.Log("PLAYER MAX HEALTH");
            this.SetMaxLife();
            healthManager.currentLife = (int)lifeSlider.maxValue;
        }
        else
        {
            lifeSlider.value = updatedLife;
            healthManager.currentLife = updatedLife;
        }
    }

    // Test if the player died by life
    private bool isLifeEnded()
    {
        if (healthManager.currentLife <= 0)
        {
            return true;
        }
        return false;
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
