using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    private Transform jogador;
    public Transform bala1;
    private float speed = 25;
    private bool mova = false;
    private float distance; 

    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
        //bala1.transform.position = jogador.transform.position;
        
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

        if (Input.GetMouseButtonDown(1) || mova)
        {

           
            
            if (!mova)
            {     
                bala1.transform.position = jogador.transform.position;           
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0.0f;
                direction = mousePosition;
            }

            bala1.transform.position += direction.normalized * speed * Time.deltaTime;
            mova = true;

            distance = Vector3.Distance (bala1.transform.position, jogador.transform.position);
            if(distance > 25)
            {

                mova = false;
                bala1.transform.position = new Vector3(32, 6, 0);
                
            }

        }

        if (!mova)
        {

            //bala1.transform.position = jogador.transform.position;
            bala1.transform.position = new Vector3(32, 6, 0);

        }

    }      

 }
    
