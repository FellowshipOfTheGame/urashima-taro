using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Slider lifeSlider;
    public Gradient gradient;
    public Image fill;
    private HealthManager healthManager;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        GetHealthmanagerLife();
    }

    void Update()
    {
        // temp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.UpdateCurrentLife(-2);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            this.UpdateCurrentLife(2);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.UpdateMaxLife(-5);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            this.UpdateMaxLife(5);
        }
    }

    // Set the life bar with the current status of the life manager
    private void GetHealthmanagerLife()
    {
        lifeSlider.maxValue = healthManager.maxLife;
        lifeSlider.value = healthManager.currentLife;
        fill.color = gradient.Evaluate(lifeSlider.normalizedValue);
    }

    // Change the max of the life slider and healthManager, meaning that the maximum life of the player has changed
    public void UpdateMaxLife(int lifeAddiction)
    {
        int updatedMaxLife = healthManager.maxLife + lifeAddiction;

        if (updatedMaxLife > 0)
        {
            lifeSlider.maxValue = updatedMaxLife;
            healthManager.maxLife = updatedMaxLife;

            if (updatedMaxLife < lifeSlider.value)
            {
                lifeSlider.value = updatedMaxLife;
                healthManager.currentLife = updatedMaxLife;
            }
        }
        else
        {
            //Debug.Log("PLAYER IS DEAD 'CAUSE THE MAX LIFE IS ZERO");
            lifeSlider.maxValue = 0;
            healthManager.maxLife = 0;
            healthManager.currentLife = 0;
        }
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
            Debug.Log("PLAYER DIED FROM LIFE");
            healthManager.currentLife = 0;
            lifeSlider.value = 0;
        }
        // Test if the current life exceded the maximum life value
        else if (updatedLife > lifeSlider.maxValue)
        {
            Debug.Log("PLAYER MAX HEALTH");
            this.SetMaxLife();
        }
        else
        {
            lifeSlider.value = updatedLife;
            healthManager.currentLife = updatedLife;

        }
        fill.color = gradient.Evaluate(lifeSlider.normalizedValue);
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
}
