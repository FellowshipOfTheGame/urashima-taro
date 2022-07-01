using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is used to teleport the Player using collision
 * (to another scene position or some position in the same scene)
 * The player object needs to have the Tag "Player".
 */
public class CollisionTeleport : MonoBehaviour
{
    [SerializeField] Transform destinyPosition;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject player = col.gameObject;
        if (player.tag == "Player")
        {
            Debug.Log(player.transform.position);
            player.transform.position = destinyPosition.position;
        }
    }
}
