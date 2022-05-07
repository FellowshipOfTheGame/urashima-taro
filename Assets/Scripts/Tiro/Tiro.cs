using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    public Transform jogador;
    public Transform bala1;
    private float speed = 20;
    private float SPEED = 1;   
    private bool mova = false;
    private Camera cam;
    private Vector3 newPosition;

    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {

        bala1.transform.position = jogador.transform.position;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        direction = (mousePosition - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {             
        
        InputShoot();

    }
    
    void InputShoot()
    {     

        if (Input.GetMouseButtonDown(0) || mova)
        {

            if (!mova)
            {

                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0.0f;
                direction = (mousePosition - transform.position).normalized;

            }

            bala1.transform.position += direction * speed * Time.deltaTime;
            mova = true;

           if(bala1.transform.position.x >= 14.0f || bala1.transform.position.x <= -14.0f || bala1.transform.position.y >= 6.0f || bala1.transform.position.y <= -6.0f)
            {

                mova = false;
                bala1.transform.position = jogador.transform.position;
                bala1.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);

            }

        }

        if (!mova)
        {

            bala1.transform.position = jogador.transform.position;

        }

    }      

 }
    
