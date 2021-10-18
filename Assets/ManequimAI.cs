using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ManequimAI : MonoBehaviour
{
    public Transform target;

    [Header("Move Parameters")] public float speed;
    public float nextWayPointDistance;

    [Header("Attack Parameters")] public float attackRange;

    [Header("Settings")] public bool isFirstStopOn;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        InvokeRepeating("PathUpdate", 0f, 0.5f);
        InvokeRepeating("DirectionUpdate", 0f, 0.2f);
    }



    Vector3 velocity;

    //calcula o caminho do manequim
    private void PathUpdate()
    {
        if (seeker.IsDone() || reachedEndOfPath)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        
    }

    //calcula a direcao do manequim
    private void DirectionUpdate()
    {
        if(!reachedEndOfPath)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
            float xAngle = Vector2.Angle(direction, new Vector2(100000, 0));
            float yAngle = Vector2.Angle(direction, new Vector2(0, 100000));
            Vector2 velocity2 = new Vector2(0, 0);

            //decide a direcao entre os 8 direcoes(falta animacao) 
            if (xAngle < 22.5f)
            {
                //direita
                velocity2 = new Vector2(1, 0);
            }
            else if (xAngle < 67.5f)
            {
                //direita superior
                if(yAngle < 90) velocity2 = new Vector2(1, 1);
                //direita inferior
                else velocity2 = new Vector2(1, -1);
            }
            else if(xAngle < 112.5f)
            {
                //cima
                if (yAngle < 90) velocity2 = new Vector2(0, 1);
                //baixo
                else velocity2 = new Vector2(0, -1);
            }
            else if (xAngle < 157.5f)
            {
                //esquerda superior
                if (yAngle < 90) velocity2 = new Vector2(-1, 1);
                //esqruerda inferior
                else velocity2 = new Vector2(-1, -1);
            }
            else
            {
                //esquerda
                velocity2 = new Vector2(-1, 0);
            }
            
            //deixa o modulo da velocidade constante
            velocity2 = velocity2.normalized * speed;
            
            velocity = new Vector3(velocity2.x, velocity2.y, 0f);
        }
    }


    //reseta o caminho
    private void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }



    bool isActive = false;
    bool isStop = false;
    void FixedUpdate()
    {
        //mouse representa o som
        if(Input.GetKey(KeyCode.Mouse0) && !isActive)
        {
            //faz a animacao
            StartMove();
        }

        
        if(isActive && !isStop)
        {
            float playerDistance = ((Vector2)target.transform.position - (Vector2)this.transform.position).magnitude;
            if (playerDistance < attackRange)
            {
                ReachPlayer();
            }

            else
            {
                MoveManequim();
            }
        }

        //mouse representa o player esconder
        if(Input.GetKey(KeyCode.Mouse1) && isActive)
        {
            StopMove();
        }
    }



    #region //Start Move
    private void StartMove()
    {
        sprite.material.color = new Color(0, 255, 0);
        isActive = true;
        isStop = true;
        if(isFirstStopOn)
        {
            StartCoroutine(FirstStop());
            //faz animacao
            sprite.material.color = new Color(255, 255, 0);
        }
        else
        {
            isStop = false;
            sprite.material.color = new Color(255, 0, 0);
        }

    }

    private IEnumerator FirstStop()
    {
        
        //o tempo, depois troca para tempo da animacao
        yield return new WaitForSeconds(1f);
        isStop = false;
        sprite.material.color = new Color(255, 0, 0);
    }
    #endregion

    #region //ReachPlayer
    private void ReachPlayer()
    {
        isStop = true;
        //faz animacao de ataque
        sprite.material.color = new Color(0, 255, 225);
        StartCoroutine(AttackStop());
    }

    private IEnumerator AttackStop()
    {
        //o tempo, depois troca para tempo da animacao
        yield return new WaitForSeconds(1f);
        isStop = false;
        sprite.material.color = new Color(255, 0, 0);
    }
    #endregion

    #region //Move Manequim
    private void MoveManequim()
    {
        if (path == null)
            return;

        //checa se ja chegou no final
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
        }
        //se nao estiver chegado, move o manequim
        else
        {
            reachedEndOfPath = false;

            //move o Manequim
            transform.position += velocity / 100 * Time.deltaTime;

            //vai para proximo WayPoint se passou o WayPoint Atual
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
            if (distance < nextWayPointDistance)
            {
                currentWayPoint++;
            }
        }
    }
    #endregion

    #region // Stop Move
    void StopMove()
    {
        isActive = false;
        isStop = true;
        //faz animacao
        sprite.material.color = new Color(255, 255, 255);
    }
    #endregion
}