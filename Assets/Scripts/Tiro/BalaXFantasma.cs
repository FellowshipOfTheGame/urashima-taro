using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaXFantasma : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform fantasma;
    public Transform bala1;
    public Transform jogador;
    float distanciaBalaFantasma;
    float distanciaJogadorFantasma;
    int index = 0;
    Flag marca = new Flag();
    
    void Start()
    {
        
    }

    void Update()
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
    
    void posicaoFantasma()
    {
    
       index = (int) Random.Range(0.0f, 3.0f);   
       if (index == 0) fantasma.transform.position = new Vector3(-7, 2, 0);
       if (index == 1) fantasma.transform.position = new Vector3(17, 7, 0);
       if (index == 2) fantasma.transform.position = new Vector3(3, -6, 0);
       if (index == 3) fantasma.transform.position = new Vector3(-7, 2, 0);
    
    }
    
}
