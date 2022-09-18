using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Used for access the preload scene from any scene and other stuffs
// This is a Singleton
// obs: ONLY USED FOR DEVELOPMENT, NOT IMPLEMENTED FOR THE GAME
public class DevPreload : MonoBehaviour
{
    public static DevPreload Instance { get; private set; }
    public enum Type {_preload, Menu, Test, Teoi, HerbertH, HerbertH2, HerbertH3, TesteHerbert, ZombieTest };
    public Type nextScene;
    [SerializeField] private Vector3 destinyPosition;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        Debug.Log(nextScene);

        GameObject check = GameObject.Find("__app");

        if (check == null)
        {
            SceneManager.LoadScene("_preload");
        }

        if (destinyPosition != null)
        {
            GameObject player = GameObject.FindWithTag("Player");

            player.transform.position = destinyPosition;
        }
    }
}
