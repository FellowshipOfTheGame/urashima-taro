using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    public Transform jogador;
    public Transform bala1;
    private float speed = 5;
    private bool mova = false;
    private Camera cam;
    private Vector3 newPosition;
    private float distance; 

    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {

        bala1.transform.position = jogador.transform.position;
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

                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0.0f;
                direction = mousePosition;
            }

            bala1.transform.position += direction * speed * Time.deltaTime;
            mova = true;

           distance = Vector3.Distance (bala1.transform.position, jogador.transform.position);
           if(distance > 30)
            {

                mova = false;
                bala1.transform.position = new Vector3(32, 6, 0);
                
            }

        }

        if (!mova)
        {

            bala1.transform.position = jogador.transform.position;

        }

    }      

 }
    
