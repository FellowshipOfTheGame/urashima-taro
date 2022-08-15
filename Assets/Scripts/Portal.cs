using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    private Transform jogador;
    private Transform portal;
    float distancia;
    
    // Start is called before the first frame update
    void Start()
    {
        
        jogador= GameObject.FindWithTag("Player").transform;
        portal = GameObject.FindWithTag("Portal1").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
    
         distancia = Vector3.Distance(jogador.transform.position, portal.transform.position);
         
         if (distancia <= 0) 
         {
         
            SceneManager.LoadScene("HerbetH3");
         
         } 
        
    }
}
