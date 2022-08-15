/*Alexandre 15/10/2021*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacarMoverLimitar : MonoBehaviour
{

  
    private Vector2 fantasma_V;
    private float velocidadeRecuo = 0.5f;
    private Transform jogador;
    public Transform fantasma;
    public float velocidade = 0.05f;
    public float velocidadeDeAtaque = 0.01f;
    public float raioAlvo = 8f;
    public float tempoSec = 2.0f;
    public float retorno = 0.05f;
    private AudioManager audioManager;
    float distance;
    float direcao;
    private Flag marca;
        
    void Start()
    {
      marca = FindObjectOfType<Flag>();
      jogador = GameObject.FindWithTag("Player").transform;
      audioManager = FindObjectOfType<AudioManager>();
      audioManager.Play("Walking");
    
    }

    void Update()
    {               
        
        //quando jogo for pausado nao move
      if (Time.timeScale == 0) return;
      distance = Vector3.Distance(jogador.transform.position, fantasma.transform.position);
        
      if(marca.getFantasmaAtaque() > 0)
      {
          
        ataque();  
         
      } 
      else
      {
         
        audioManager.Stop("Walking");
          
      }            
        
    }

    void ataque()
    {            
    
      if (distance <= raioAlvo && marca.getAtaque())
      {
      
       fantasma.transform.position = Vector3.MoveTowards(fantasma.transform.position, jogador.transform.position, Time.fixedDeltaTime * velocidadeDeAtaque);
       
      }
        
    } 
       
}
