using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //variaveis do jogador que deverao ser salvos
    [HideInInspector] public int vidaAtual;
    [HideInInspector] public float[] position;
    [HideInInspector] public int tirosAtuais;

    //pega dados e junta no variavel tipo "PlayerData"
    public PlayerData (PlayerSaveVariables player)
    {
        //parametros da vida
        vidaAtual = player.vidaAtual;

        //posicao do Player
        position = new float[3];
        position[0] = player.position[0];
        position[1] = player.position[1];
        position[2] = player.position[2];

        //parametros da arma
        tirosAtuais = player.tirosAtuais;
    }
}
