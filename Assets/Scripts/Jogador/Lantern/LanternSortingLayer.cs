using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSortingLayer : MonoBehaviour
{
    public GameObject lantern1;
    public GameObject lantern2;

    public static LanternSortingLayer Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);
    }

    public void UpLayer()
    {
        lantern1.SetActive(true);
        lantern2.SetActive(false);
    }

    public void NotUpLayer()
    {
        lantern1.SetActive(false);
        lantern2.SetActive(true);
    }
}
