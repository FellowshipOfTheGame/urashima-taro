using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
            audioManager.Play("Box");
    }
}
