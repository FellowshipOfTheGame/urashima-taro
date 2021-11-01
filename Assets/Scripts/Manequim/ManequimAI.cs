using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ManequimAI : MonoBehaviour
{
    public Transform target;

    [Header("Move Parameters")] public float speed;

    [Header("Attack Parameters")] public float attackRange;

    [Header("Settings")] public bool isFirstStopOn;
    
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    float nextWayPointDistance = 0.5f;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        if (sprite == null) Debug.Log("null");
        InvokeRepeating("PathUpdate", 0f, 0.5f);
        float repeatFrequency = speed / 5000.0f;
        InvokeRepeating("DirectionUpdate", 1f, repeatFrequency);
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
        if (!reachedEndOfPath)
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
                if (yAngle < 90) velocity2 = new Vector2(1, 1);
                //direita inferior
                else velocity2 = new Vector2(1, -1);
            }
            else if (xAngle < 112.5f)
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
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }



    bool isActive = false;
    bool isStop = false;
    bool isHear = false;

    void FixedUpdate()
    {
        if (isHear && !isActive)
        {
            StartMove();
        }

        if (isActive && !isStop)
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
        /* if (Input.GetKey(KeyCode.Mouse1) && isActive)
         {
             StopMove();
         }*/


        if (isHear) isHear = false;
    }


    #region //Start Move
    private void StartMove()
    {
        sprite.color = new Color(0, 1, 0, 1);
        isActive = true;
        isStop = true;
        if (isFirstStopOn)
        {
            StartCoroutine(FirstStop());
            //faz animacao
            sprite.color = new Color(1, 1, 0, 1);
        }
        else
        {
            isStop = false;
            sprite.color = new Color(1, 0, 0, 1);
        }

    }

    private IEnumerator FirstStop()
    {

        //o tempo, depois troca para tempo da animacao
        yield return new WaitForSeconds(1f);
        isStop = false;
        sprite.color = new Color(1, 0, 0, 1);
    }
    #endregion

    #region //ReachPlayer
    private void ReachPlayer()
    {
        isStop = true;
        //faz animacao de ataque
        sprite.color = new Color(0, 1, 1, 1);
        StartCoroutine(AttackStop());
    }

    private IEnumerator AttackStop()
    {
        //o tempo, depois troca para tempo da animacao
        yield return new WaitForSeconds(1f);
        isStop = false;
        sprite.color = new Color(1, 0, 0, 1);
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
        sprite.color = new Color(1, 1, 1, 1);
    }
    #endregion

    #region //Som
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sound"))
            isHear = true;
    }
    #endregion
}