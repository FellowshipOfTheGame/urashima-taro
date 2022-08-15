using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleTextoCredito : MonoBehaviour
{
    public Text credito1;
    string str;
    float tempoChamadaNome = 0.0F;
    float tempoSaidaCena   = 0.0F;
    int num;
    int index;
    string[] nomes = {"Jhonatas Paolozza - Coordinator",
                      "Herbert Heinz - 2D Artist, Game Design, Screenplay and History",
                      "Kaito Hayashi - 2D Artist and Programmer",
                      "Bernardo T. - 2D Artist","Julia Frare - 2D Artist",
                      "Thales Castro - Sounds and effects", 
                      "Alexandre Martins - Programmer", 
                      "Tyago Yuji Teoi - Programmer", 
                      "Paolo Victor - Programmer and Game Design",
                      "Rodrigo Lima - Programmer",
                      "Press esc to get out"};
  
    void Start()
    {
        credito1.text = "";
        index = 0;
    }

    void Update()
    {       
       
       if(index < nomes.Length)
       {
       
          tempoChamadaNome += Time.deltaTime;
          
          if (tempoChamadaNome >= 3)
	  {
		         
	   tempoChamadaNome = 0; 
	   str = str + nomes[index] + "\n";
	   credito1.text = str;
	   index ++;
		  
	 }     
          
      }
            
      if (tempoSaidaCena <= 40)
      {
       
          tempoSaidaCena += Time.deltaTime;      
          
      }
      else
      {
       
          SceneManager.LoadScene("TelaInicial");
                
      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
            
          SceneManager.LoadScene("TelaInicial");  
            
      }       
               
    }       
    
}
