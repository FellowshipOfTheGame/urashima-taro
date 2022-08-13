using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconder : Interactable
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

    public bool isHidden = false;

    private void Start()
    {
        // Trocar para nome do gameobject do jogador
        jogador = GameObject.FindGameObjectWithTag("Player");
    }

    public override string Descricao()
    {
        if (!isHidden)
            return "Pressione E para se esconder";

        return "Pressione E para sair do esconderijo";
    }

    public override void Acender()
    {
        outline.SetActive(true);
    }

    public override void Apagar()
    {
        outline.SetActive(false);
    }

    public override void Interagir()
    {
        if (!isHidden)
        {
            // tocar animacao entrada

            isHidden = true;

            jogador.transform.position = transform.position;

            // Suposto lugar para testar se o zumbi esta vendo o jogador se esconder aqui(seta o 'viuSeEsconder' do pseudocodigo lah)
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
        else if (isHidden)
        {
            // tocar animacao saida
            jogador.SetActive(true);

            jogador.GetComponent<PlayerCollision>().isHidden = false;

            jogador.gameObject.transform.position = pontoAbertura.position;

            isHidden = false;
        }
    }

    public override bool EstahAtivo()
    {
        return false;
    }
}
