using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFantasmaActive : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject player = col.gameObject;
        if (player.tag == "Player")
        {
            FindObjectOfType<Flag>().setAtaque(true);
        }
    }
}
