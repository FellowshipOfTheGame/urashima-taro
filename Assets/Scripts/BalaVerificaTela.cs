using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaVerificaTela : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform jogador;
    public Transform bala1;
    public Collider2D colBala;
    public Collider2D alvoFantasma;
    public Collider2D alvoManequim;
    public Collider2D alvoZumbi;
    public Transform t_Fantasma;
    public Transform t_Manequim;
    public Transform t_Zumbi;
    public GameObject bala;
    float distancia = 0;
    float speed = 10;
    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;
    Renderer m_Renderer;
     
    void Start()
    {
        
        m_Renderer = GetComponent<Renderer>();      
               
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKey("up"))
        {
        
           up = true;
           bala1.transform.position = jogador.transform.position;
         
        }
        if(Input.GetKey("down"))
        { 
        
           down = true;
           bala1.transform.position = jogador.transform.position;
        
        }
        if(Input.GetKey("left"))
        {
        
           left = true;
           bala1.transform.position = jogador.transform.position;
         
        }        
        if(Input.GetKey("right")) 
        {
         
           right = true;
           bala1.transform.position = jogador.transform.position;
           
        }
        
        if (m_Renderer.isVisible)
        {
        
           if(up)    bala1.transform.Translate(Vector3.up    * speed * Time.deltaTime, Camera.main.transform); 
           if(down)  bala1.transform.Translate(Vector3.down  * speed * Time.deltaTime, Camera.main.transform); 
           if(left)  bala1.transform.Translate(Vector3.left  * speed * Time.deltaTime, Camera.main.transform); 
           if(right) bala1.transform.Translate(Vector3.right * speed * Time.deltaTime, Camera.main.transform); 
          
        }
        else
        {
        
           up    = false;
           down  = false;
           left  = false;
           right = false;
           m_Renderer.material.color = Color.clear; 
           
        }
        
        if(alvoFantasma != null)
        {
            
           kill(bala1, t_Fantasma);
              
        }
                    
        if(alvoManequim != null) 
        {
              
            kill(bala1, t_Manequim);
                 
        }
            
        if(alvoZumbi != null) 
        {
                              
          kill(bala1, t_Zumbi);
                
        }  
 
    }
    
    void kill(Transform bala, Transform  alvo)
    {
    
      distancia = Vector3.Distance(bala.position, alvo.position); 
      
      if(distancia < 0.9)
      {
      
         bala.transform.position = jogador.transform.position;
         alvo.transform.position = new Vector3(100,100,100);
         up    = false;
         down  = false;
         left  = false;
         right = false;
      
      }
      
    }          
    
}

