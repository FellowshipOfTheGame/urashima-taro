/*
Autor: Alexandre
Data: 7/11/22
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    public Transform jogador;
    public Transform bala1;
    public Collider2D colBala;
    public Collider2D alvoFantasma;
    public Collider2D alvoManequim;
    public Collider2D alvoZumbi;
    //public Camera cam;
    public GameObject bala;


    private Camera cam;


    private float speed = 20;
    private bool mova = false;
    private Vector3 newPosition;
    private float distance;
    private int voltas = 20;
    private Renderer m_Renderer;

    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
        bala1.transform.position = new Vector3(32, 6, 0);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        direction = (mousePosition - transform.position).normalized;

        bala1.transform.position = jogador.transform.position;

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

            distance = Vector3.Distance(bala1.transform.position, jogador.transform.position);
            if (distance > 25)
            {

                mova = false;
                bala1.transform.position = new Vector3(32, 6, 0);

            }

        }

        if (Input.GetKey("up"))
        {

            while (voltas > 0)
            {

                bala1.transform.Translate(Vector3.up * speed * Time.deltaTime, Camera.main.transform);
                voltas--;
            }

            voltas = 20;

        }
        else
        {

            if (Input.GetKey("down"))
            {

                while (voltas > 0)
                {

                    bala1.transform.Translate(Vector3.down * speed * Time.deltaTime, Camera.main.transform);
                    voltas--;

                }

                voltas = 20;

            }
            else
            {

                if (Input.GetKey("left"))
                {

                    while (voltas > 0)
                    {

                        bala1.transform.Translate(Vector3.left * speed * Time.deltaTime, Camera.main.transform);
                        voltas--;

                    }

                    voltas = 20;

                }
                else
                {

                    if (Input.GetKey("right"))
                    {

                        while (voltas > 0)
                        {

                            bala1.transform.Translate(Vector3.right * speed * Time.deltaTime, Camera.main.transform);
                            voltas--;

                        }

                        voltas = 20;

                    }

                }

            }

        }





        /*  if(alvoFantasma != null)
          {

            kill(colBala, alvoFantasma);

          }

          if(alvoManequim != null) 
          {

              kill(colBala, alvoManequim);

          }

          if(alvoZumbi != null) 
          {

             kill(colBala, alvoZumbi);

          }     */





    }

    void kill(Collider2D bala, Collider2D alvo)
    {

        if (bala.IsTouching(alvo))
        {

            Debug.Log("acertou " + alvo.transform.tag);
            bala.transform.position = jogador.transform.position;
            mova = false;
            alvo.transform.position = new Vector3(100, 100, 100);
            Destroy(alvo);

        }

    }

}

