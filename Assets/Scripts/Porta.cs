using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{

    public GameObject porta;
    

    void Start()
    {
        
    }

    void Update()
    {

        if (Flag.porta)
        {

            float posiEmX = porta.transform.position.x;
            float posiEmY = porta.transform.position.y;

            porta.transform.position = new Vector3(posiEmX, (posiEmY + 2), 0.0f);//definir qual o evento ocorrera sobre a porta.
            Flag.porta = false;

        }
        
    }
}
