using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    public  Transform jogador;
    public  Transform bala1;
    public  Collider2D colBala;
    public  Collider2D alvoFantasma;
    public  Collider2D alvoManequim;
    public  Collider2D alvoZumbi;
        
    private float speed = 25;
    private bool mova = false;
    private Camera cam;
    private Vector3 newPosition;
    private float distance; 

    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {
    
        bala1.transform.position = new Vector3(32, 6, 0);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        direction = (mousePosition - transform.position).normalized;

    }
    
    void Update()
    {             
        
        InputShoot();

    }
    
    void InputShoot()
    {     

        if (Input.GetMouseButtonDown(0) || mova)
        {           
                        
            if (!mova)
            {     
                bala1.transform.position = jogador.transform.position;           
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0.0f;
                direction = mousePosition;
                mova = true;
            }

            bala1.transform.position += direction.normalized * speed * Time.deltaTime;            
            distance = Vector3.Distance (bala1.transform.position, jogador.transform.position);
            
            if(distance > 25)
            {
            
                bala1.transform.position = jogador.transform.position;
                mova = false;
                
            }
            
            
            if(alvoFantasma != null)
            {
            
              kill(colBala, alvoFantasma);
              
            }
                    
            if(alvoManequim != null) 
            {
              
                kill(colBala, alvoManequim);
                 
            }
            
            if(alvoZumbi != null) 
            {
                              
               kill(colBala, alvoZumbi);
                
            }            
 
        }
       
        
    }      
    
    void kill(Collider2D bala, Collider2D  alvo)
    {
    
      if (bala.IsTouching(alvo)) 
      {
      
         Debug.Log("acertou " + alvo.transform.tag);
         bala.transform.position = jogador.transform.position;
         mova = false;
         alvo.transform.position = new Vector3(100,100,100);
         Destroy(alvo);
          
      }           
       
    } 
   
 }
    
