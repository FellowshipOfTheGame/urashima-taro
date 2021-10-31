using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{ 
    public int maxLife;
    public int maxSanity;
    public int currentLife;
    public int currentSanity;

    void Start()
    {
        currentLife = maxLife;
        currentSanity = maxSanity;
    }
}
