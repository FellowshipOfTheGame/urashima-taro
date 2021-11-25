using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconder : MonoBehaviour
{
    // semi pseudo codigo para qndo o inimigo ve o player se esconder
    /*
     * if(viuSeEsconder)
     * {
     *      destino = pontoAbertura;
     *      
     *      if(gameObject.transform.position = PontoAbertura)
     *      {
     *          RetirarPlayer();
     *      }
     * }
     * else
     * {
     *      codigo atual (linhas 59 - 68 ZombieDestinationSetter.cs)
     * }
     * 
    */

    [SerializeField] Transform pontoAbertura;

    [SerializeField] GameObject outline;

    GameObject jogador;

    public bool isHidden;
    bool inRange;


    // Update is called once per frame
    void Update()
    {
        MoverPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // sistema temporario ate completar o sistema de interacao
        if(collision.gameObject.CompareTag("Player"))
        {
            inRange = true;

            jogador = collision.gameObject;

            outline.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isHidden)
        {
            inRange = false;

            outline.SetActive(false);
        }
    }

    private void MoverPlayer()
    {
        if (inRange)
        {
            if (!isHidden && InputManager.GetInstance().GetInteragir())
            {
                // tocar animacao entrada

                outline.SetActive(false);

                isHidden = true;

                jogador.transform.position = gameObject.transform.position;
                // Testa se o zumbi esta vendo o jogador se esconder aqui(seta o 'viuSeEsconder' do pseudocodigo lah)
                /* if (zombieView.canSeePlayer)
                 * {
                 *      jogador.GetComponent<PlayerCollision>().isHidden = false;
                 * }
                 * else
                        jogador.GetComponent<PlayerCollision>().isHidden = true;
                */
                jogador.GetComponent<PlayerCollision>().isHidden = true;
                jogador.SetActive(false);
            }
            else if (isHidden && InputManager.GetInstance().GetInteragir())
            {
                // tocar animacao saida

                outline.SetActive(true);

                jogador.SetActive(true);

                jogador.GetComponent<PlayerCollision>().isHidden = false;

                jogador.gameObject.transform.position = pontoAbertura.position;

                isHidden = false;
            }
        }
    }
}
