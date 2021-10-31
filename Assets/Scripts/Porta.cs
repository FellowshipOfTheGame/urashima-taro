using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{

    public GameObject porta;
    public GameObject jogador;
    float distancia  = 0f;
    public float raioPorta = 3f;
    bool abrir = false;


    void Start()
    {
        
    }

    void Update()
    {

      distancia = Vector3.Distance(jogador.transform.position, porta.transform.position);

      if (Flag.porta && distancia < raioPorta)
        {           

                float posiEmX = porta.transform.position.x;
                float posiEmY = porta.transform.position.y;

                porta.transform.position = new Vector3(posiEmX, (posiEmY + 2), 0.0f);//definir qual o evento ocorrera sobre a porta.
                Flag.porta = false;                                 

        }
        
    }
}
/*
 InvalidOperationException: You are trying to read Input using the UnityEngine.Input class, but you have switched active Input handling to Input System
package in Player Settings.
UnityEngine.Input.GetKey (UnityEngine.KeyCode key) (at <6af207ecd21044628913f7cc589986ae>:0)
Porta.Update () (at Assets/Scripts/Porta.cs:31)
 */