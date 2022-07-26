using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleTextoCredito : MonoBehaviour
{
    int num;
    int index;
    string[] nomes = {"Jhonatas Paolozza - Coordinator","Herbert Heinz - 2D Artist, Game Design, Screenplay and History.","Kaito Hayashi - 2D Artist and Programmer","Bernardo T. - 2D Artist","Julia Frare - 2D Artist","Thales Castro - Sounds and effects", "Alexandre Martins - Programmer", "Tyago Yuji Teoi - Programmer", "Paolo Victor - Programmer and Game Design","Rodrigo Lima - Programmer"};
    
    public Text credito1;
    string str;
    const int MAXIMORANGE  = 1000000;
    // Start is called before the first frame update
    void Start()
    {
        credito1.text = "";
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {             
        
        
        num = Random.Range(0, MAXIMORANGE);
        
         Debug.Log(num);       
        if(5 < num  && index < nomes.Length)
        { 
        
            str = str + nomes[index] + "\n";
            //str = nomes[index] + "\n";
            credito1.text = str;
            index ++;
        
        }     
               
        
    }    
    
    
}
