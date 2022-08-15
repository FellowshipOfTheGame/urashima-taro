using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaXFantasma : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform fantasma;
    public Transform bala1;
    private Transform jogador;
    float distanciaBalaFantasma;
    float distanciaJogadorFantasma;
    int index = 0;
    Flag marca = new Flag();
    
    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
        // This work only for one 'fantasma'
        // If, in the future, more than one ghost will appeir in the scene
        // 'fantasma' have to be a list of fantasmas
        fantasma = GameObject.Find("Fantasma").transform;
    }

    void Update()
    {
        if (fantasma != null)
        {
            distanciaBalaFantasma = Vector3.Distance (bala1.transform.position, fantasma.transform.position);        
        
            if(distanciaBalaFantasma <= 0)//Fantasma é morto. 
            {        
           
               posicaoFantasma();
           
            }       
       
            distanciaJogadorFantasma = Vector3.Distance (jogador.transform.position, fantasma.transform.position);
       
            if(distanciaJogadorFantasma <= 0.5)
            {
       
             marca.setFantasmaAtaque(1);        
             if(marca.getFantasmaAtaque() > 0)
              {
          
                 posicaoFantasma();
          
              }
              else
              {
          
                   fantasma.transform.position = new Vector3(100, 100, 0);
          
              }                   
       
           }           
        }
       
    }    
    
    void posicaoFantasma()
    {
    
       index = (int) Random.Range(0.0f, 3.0f);   
       if (index == 0) fantasma.transform.position = new Vector3(-100, 250, 0);
       if (index == 1) fantasma.transform.position = new Vector3(100, 200, 0);
       if (index == 2) fantasma.transform.position = new Vector3(-100, 215, 0);
       if (index == 3) fantasma.transform.position = new Vector3(-100, 200, 0);
    
    }
    
}
