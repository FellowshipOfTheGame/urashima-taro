using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura : MonoBehaviour
{
    [Header("Armadura")] [SerializeField] int vidaArmor;
    private Vida vida = null;
    private string playerTag = "Player";

    void Start()
    {
        GameObject player = GameObject.Find("Jogador 1");
        if (player == null) Debug.Log("Player Not Found");
        vida = player.GetComponent<Vida>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            vida.SetVidaExtra(vidaArmor);
            Destroy(this.gameObject);
        }
    }
}
