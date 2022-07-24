using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleTextoCredito : MonoBehaviour
{
    int num;
    int index;
    string[] nomes = {"nome1","nome2","nome3","nome4","nome5","nome6"};
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
