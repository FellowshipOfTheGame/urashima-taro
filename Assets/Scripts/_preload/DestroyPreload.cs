using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPreload : MonoBehaviour
{
    private void Start()
    {
        DeleteAll();
    }
    void DeleteAll()
    {
        Debug.Log("entrou");
        GameObject app = GameObject.Find("__app");
        GameObject audio = GameObject.Find("__audio");
        GameObject scene = GameObject.Find("__scene");
        GameObject player = GameObject.Find("__player");

        if (app == null) Debug.Log("null");
        Destroy(app);
        Destroy(audio);
        Destroy(scene);
        Destroy(player);
    }
}
