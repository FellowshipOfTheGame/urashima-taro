using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Utilizacao
//Coloca a Pistola no Shoot Sc
//Chame a funcao SavePlayer quando quer salvar os dados
//e a funcao LoadPlayer quando quer carregar os dados


//Funcionamento
//PlayerSaveVariables - pega todos variaveis que quer salvar do player
//                    - SavePlayer - junta e manda dados para SaveSystem
//                    - LoadPlayer - pega dados do SaveSystem e coloca em outros Scripts
//
//SaveSystem - SavePlayer - pega dados do jogador e coloca num file(para conseguir salvar)
//           - LoadPlayer - pega dados do file e da o retorno
//
//PlayerData - funciona tipo um variavel(eu acho), que contem todos tipos de dados que quer salvar


public class PlayerSaveVariables : MonoBehaviour
{
    [HideInInspector] public int vidaAtual;
    [HideInInspector] public float[] position;
    [HideInInspector] public int tirosAtuais;


    //pega Componentes
    private Vida vidaSc;
    public Shooting shootSc;
    private void Start()
    {
        vidaSc = this.GetComponent<Vida>();
        if (shootSc == null) Debug.Log("null");
    }


    //pega os variaveis de outros scripts
    //e manda o Script SaveSystem salvar as variaveis
    public void SavePlayer()
    {
        //parametros da vida
        vidaAtual = vidaSc.vidaAtual;

        //posicao do Player
        position = new float[3];
        position[0] = this.transform.position.x;
        position[1] = this.transform.position.y;
        position[2] = this.transform.position.z;

        //parametros da arma
        tirosAtuais = shootSc.tirosAtuais;

        //manda dados para SaveSystem
        SaveSystem.SavePlayer(this);
    }


    //pega dados salvos e coloca em cada Script
    public void LoadPlayer()
    {
        //pega dados do SaveSystem
        PlayerData data = SaveSystem.LoadPlayer();


        //parametros da vida
        vidaSc.vidaAtual = data.vidaAtual;

        //posicao do Player
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        //parametros da arma
        shootSc.tirosAtuais = data.tirosAtuais;
    }
}
