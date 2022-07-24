using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//faz o teleporte do player
public class TeleportManager : MonoBehaviour
{
    public static TeleportManager instance = null;
    [HideInInspector] public Vector3 teleportPos = new Vector3(0,0,0);

    //metodo usado para nao existir mais de um TeleportManager na cena
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //teleporta o player quando carrega a cena
    private void OnLevelWasLoaded(int level)
    {
        GameObject player = GameObject.Find("Jogador 1");
        if (player == null)
        {
            Debug.LogWarning("Verifique se o nome do jogador e `Jogador1`");
            return;
        }

        if (teleportPos != new Vector3(0, 0, 0))
        {
            player.transform.position = teleportPos;
            teleportPos = new Vector3(0, 0, 0);
        }
    }
}
