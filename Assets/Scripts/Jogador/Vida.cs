using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] int vidaMax;

    // TODO: tornar vidaAtual private

    public int vidaAtual;

    BarraDeVida barraScript;

    void Start()
    {
        GameObject hp;

        hp = GameObject.Find("UI/UI_Jogador/HP");
        barraScript = hp.GetComponent<BarraDeVida>();

        vidaAtual = vidaMax;
        barraScript.DefinirVidaMax(vidaMax);
    }

    void Update()
    {
        // temp

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Dano(5);
        }

        barraScript.DefinirVida(vidaAtual);
    }

    public void Dano(int _dano)
    {
        vidaAtual = Mathf.Clamp(vidaAtual-_dano, 0, vidaMax);

        barraScript.DefinirVida(vidaAtual);

        if (vidaAtual == 0)
        {
            // morte
            Destroy(gameObject);
        }
    }
}
