using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleTextoCredito : MonoBehaviour
{
    int num;
    public Text credito1;
    // Start is called before the first frame update
    void Start()
    {
        credito1.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
        num = Random.Range(0, 200);
        
        if(num < 100)
        {
        
             credito1.text = num.ToString();
        
        }
        
       
        
        
        
    }
}
