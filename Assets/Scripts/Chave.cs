using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    public int pontoMaximoEixoX = 10;
    public int pontoMaximoEixoY = 5;
    public float raio = 1;
    float distancia = 0;
    public GameObject jogador;
    public GameObject chave;

    void Update()
    {

        if (Flag.eventoChave)
        {

            int posiEmX = Random.Range(-pontoMaximoEixoX, pontoMaximoEixoX);
            int posiEmY = Random.Range(-pontoMaximoEixoY, pontoMaximoEixoY);

            if (Flag.insereChave)
            {

                chave.transform.position = new Vector3(posiEmX, posiEmY, 0.0f);
                Flag.insereChave = false;
                Flag.eventoChave = false;

            }

        }

        distancia = Vector3.Distance(jogador.transform.position, chave.transform.position);

        if (distancia <= raio && !Flag.insereChave)
        {

            Flag.insereChave = true;
            Flag.porta = true;
            chave.transform.position = new Vector3(pontoMaximoEixoX + 3, pontoMaximoEixoY + 3, 0.0f);

        }

    }
}


