using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovimntoAbertura : MonoBehaviour
{

     Vector3 pos;
     public float velocidade = 0.5f;
     float velocidadeX;
     float velocidadeY;
     int MUDARDIRECAO = 50;
     int MAXIMORANGE  = 99990;
     
    // Start is called before the first frame update
    void Start()
    {
         pos = transform.position;
         velocidadeX = velocidade;
         velocidadeY = velocidade;
         velocidadeX = DefinirDirecao(velocidadeX);
         velocidadeY = DefinirDirecao(velocidadeY);
    }

    // Update is called once per frame
    void Update()
    {
    
         Movendo(velocidadeX, velocidadeY);
         velocidadeX = DefinirDirecao(velocidadeX);
         velocidadeY = DefinirDirecao(velocidadeY);
         VerificarLimites();
         
    }
    
    void Movendo(float velocidadeX, float velocidadeY)
    {
    
         pos.x += velocidadeX * Time.deltaTime;
         pos.y += velocidadeY * Time.deltaTime;         
         transform.position = pos;         
    
    }
    
    private float DefinirDirecao(float velocidade)
    {
    
        int num = Random.Range(0, MAXIMORANGE);
        
        if (num < MUDARDIRECAO) 
        {
        
           return -1 * velocidade;
        
        } 
    
       return velocidade;
       
    }  
    
    private void VerificarLimites()
    {
    
           if(pos.y >= 35 || pos.y <= -5 || pos.x >= 65 || pos.x <= -25)
           {
           
              velocidadeX *= -1;
              velocidadeY *= -1;
           
           }         
    
    }           
    
}
