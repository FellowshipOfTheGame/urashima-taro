using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaXFantasma : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform fantasma;
    public Transform bala1;
    float distance;
    int index = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        distance = Vector3.Distance (bala1.transform.position, fantasma.transform.position);
        if(distance < 3) 
        {
        
           index = (int) Random.Range(0.0f, 3.0f);           
           if (index == 0) fantasma.transform.position = new Vector3(-7, 2, 0);
           if (index == 1) fantasma.transform.position = new Vector3(17, 7, 0);
           if (index == 2) fantasma.transform.position = new Vector3(3, -6, 0);
           if (index == 3) fantasma.transform.position = new Vector3(-7, 2, 0);  
           
       }     
                
    }    
    
}
