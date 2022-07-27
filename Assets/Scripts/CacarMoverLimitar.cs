/*Alexandre 15/10/2021*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacarMoverLimitar : MonoBehaviour
{

  
    private Vector2 fantasma_V;
    private float velocidadeRecuo = 0.5f;
    public Transform jogador;
    public Transform fantasma;
    //public AudioClip myClip;
    public float velocidade = 0.05f;
    public float velocidadeDeAtaque = 0.01f;
    public float raioAlvo = 8f;
    public float tempoSec = 2.0f;
    public float altura = 4.0f;
    public float comprimento = 10.0f;
    public float retorno = 0.05f;
    float distance;
    float direcao;    
    
    private AudioManager audioManager;
    //audioManager.Play("Som");
    
    
    void Start()
    {
    
      audioManager = FindObjectOfType<AudioManager>();
      audioManager.Play("Walking");
    
    }

    void Update()
    {               
        
        //quando jogo for pausado nao move
        if (Time.timeScale == 0) return;
        distance = Vector3.Distance(jogador.transform.position, fantasma.transform.position);
        ataque();
    }

    void ataque()
    {
    
         
    
        if (distance <= raioAlvo)
        {
            fantasma.transform.position = Vector3.MoveTowards(fantasma.transform.position, jogador.transform.position, Time.fixedDeltaTime * velocidadeDeAtaque);
        }
        else
        {
            limiteMovimento();
            movefantasma();
        }
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
        transform.Translate(fantasma_V * Time.fixedDeltaTime * velocidade);
    }

    void limiteMovimento()
    {

        if (transform.position.x >= comprimento)
        {

            transform.position = new Vector3(transform.position.x - retorno, transform.position.y, Time.fixedDeltaTime * velocidadeRecuo);

        }
        else
        {

            if (transform.position.x <= -comprimento)
            {

                transform.position = new Vector3(transform.position.x + retorno, transform.position.y, Time.fixedDeltaTime * velocidadeRecuo);

            }
            else
            {

                if (transform.position.y >= altura)
                {

                    transform.position = new Vector3(transform.position.x, transform.position.y - retorno, Time.fixedDeltaTime * velocidadeRecuo);

                }
                else
                {

                    if (transform.position.y <= -altura)
                    {

                        transform.position = new Vector3(transform.position.x, transform.position.y + retorno, Time.fixedDeltaTime * velocidadeRecuo);

                    }

                }

            }

        }
    }

}
