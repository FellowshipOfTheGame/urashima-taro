using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite outroSpriteFrente;
    public Sprite outroSpriteCostas;
    public Sprite outroSpriteDireita;
    public Sprite outroSpriteEsquerda;
    public Transform fantasma;
    private Transform jogador;
    private Transform posOriginal;    
    private SpriteRenderer renderSprite; 
    string resultado;
    
    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
        renderSprite = GetComponent<SpriteRenderer>();
         //posOriginal.transform.position = fantasma.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    
       direcao(fantasma, jogador);       
         
         
       
    }
    
    void direcao(Transform origem, Transform destino)
    {
    
	
	 Vector3 posA = origem.transform.position;
	 Vector3 posB = destino.transform.position;
	 Vector3 dir = (posB - posA).normalized;
	 //Debug.Log(dir.x.ToString() + " x");
	 //Debug.Log(dir.y.ToString()+ " y");   
         
        if (dir.x > 0 && dir.y > 0)//1
        {
         
            renderSprite.sprite = outroSpriteEsquerda; 
        
        } 
        
        if (dir.x < 0 && dir.y > 0)//4
        {
         
            renderSprite.sprite = outroSpriteDireita; 
        
        } 
        
        if (dir.x < 0 && dir.y < 0)//3
        {
         
            renderSprite.sprite = outroSpriteDireita; 
        
        } 
        
        if (dir.x > 0 && dir.y < 0)//3
        {
         
            renderSprite.sprite = outroSpriteEsquerda; 
        
        }
        
        if (dir.x > 0 && dir.y > 0.9)//3
        {
         
            renderSprite.sprite = outroSpriteCostas; 
        
        }
        
         if (dir.x < 0 && dir.y < -0.9)//3
        {
         
            renderSprite.sprite = outroSpriteFrente; 
        
        }
        
    }
    
       
}
