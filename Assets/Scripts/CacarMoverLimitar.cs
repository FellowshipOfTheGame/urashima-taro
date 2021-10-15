using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacarMoverLimitar : MonoBehaviour
{

    private Vector2 fantasma_V;
    private float velocidadeRecuo = 0.5f;
    public Transform jogador;
    public Transform fantasma;
    public float velocidade = 0.05f;
    public float velocidadeDeAtaque = 0.01f;
    public float raioAlvo = 8f;
    public float tempoSec = 2.0f;
    public float altura = 4.0f;
    public float comprimento = 10.0f;
    public float retorno = 0.05f;
    float distance;
    float direcao;

    void Update()
    {
        //limiteMovimento();
        distance = Vector3.Distance(jogador.transform.position, fantasma.transform.position);
        ataque();
    }

    void ataque()
    {
        if (distance <= raioAlvo)
        {
            StartCoroutine(Ataque());
        }
        else
        {
            limiteMovimento();
            movefantasma();
        }
    }

    IEnumerator Ataque()
    {
        yield return new WaitForSecondsRealtime(tempoSec);
        fantasma.transform.position = Vector3.MoveTowards(fantasma.transform.position, jogador.transform.position, velocidadeDeAtaque);
    }

    void movefantasma()
    {
        direcao = Random.Range(1f, 50000f);

        if (direcao <= 25f)
        {
            fantasma_V = Vector2.right;
        }
        else
        {
            if (direcao > 25f && direcao <= 50f)
            {
                fantasma_V = Vector2.up;
            }
            else
            {
                if (direcao > 50f && direcao <= 75f)
                {
                    fantasma_V = Vector2.down;
                }
                else
                {
                    if (direcao > 75f && direcao <= 100f)
                    {
                        fantasma_V = Vector2.left;
                    }
                }
            }
        }
        transform.Translate(fantasma_V * velocidade * Time.deltaTime);
    }

    void limiteMovimento()
    {

        if (transform.position.x >= comprimento)
        {

            transform.position = new Vector3(transform.position.x - retorno, transform.position.y, velocidadeRecuo);

        }
        else
        {

            if (transform.position.x <= -comprimento)
            {

                transform.position = new Vector3(transform.position.x + retorno, transform.position.y, velocidadeRecuo);

            }
            else
            {

                if (transform.position.y >= altura)
                {

                    transform.position = new Vector3(transform.position.x, transform.position.y - retorno, velocidadeRecuo);

                }
                else
                {

                    if (transform.position.y <= -altura)
                    {

                        transform.position = new Vector3(transform.position.x, transform.position.y + retorno, velocidadeRecuo);

                    }

                }

            }

        }
    }

}
