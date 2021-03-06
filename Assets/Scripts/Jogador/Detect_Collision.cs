using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detecta a colisao com o inimigo
//O objeto do collider do inimigo precisa estar com tag "Enemy" para a deteccao
public class Detect_Collision : MonoBehaviour
{
    [HideInInspector] public bool isEnemyHit = false;
    [HideInInspector] public int attackDamage;

    private string enemyTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == enemyTag)
        {
            isEnemyHit = true;
            attackDamage = collision.gameObject.GetComponent<Enemy_Attack>().attackDamage;
        }
            
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            isEnemyHit = true;
            attackDamage = collision.gameObject.GetComponent<Enemy_Attack>().attackDamage;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
            isEnemyHit = false;
    }
}
