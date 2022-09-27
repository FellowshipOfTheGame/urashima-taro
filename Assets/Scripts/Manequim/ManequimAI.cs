using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ManequimAI : MonoBehaviour
{
    //variaveis public
    [Header("Move Parameters")] public float chaseSpeed;
    public float backSpeed;

    [Header("Attack Parameters")] public float attackRange;

    [Header("Settings")] public bool isFirstStopOn;

    [SerializeField] private Animator _anim;
   
    //componentes do manequim
    Seeker seeker;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Vector3 firstPos;

    //static
    static float nextWayPointDistance = 0.5f;

    //componentes de fora
    private GameObject player;
    private PlayerCollision playerCollision;

    //variaveis qualquer
    Path path;
    Vector3 velocity;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    float speed;
    bool isActive = false;
    bool isStop = false;
    bool isHear = false;
    bool isBack = false;
    bool isWaiting = false;
    float waitTime = 0.0f;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
        playerCollision = player.GetComponent<PlayerCollision>();

        firstPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        InvokeRepeating("PathUpdate", 0f, 0.5f);
        float repeatFrequency = chaseSpeed / 1000;
        InvokeRepeating("DirectionUpdate", 1f, repeatFrequency);
    }


    //calcula o caminho do manequim
    private void PathUpdate()
    {
        if (seeker.IsDone() || reachedEndOfPath)
        {
            if(isBack) seeker.StartPath(rb.position, firstPos, OnPathComplete); 
            else seeker.StartPath(rb.position, player.transform.position, OnPathComplete);
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

            //decide a direcao entre os 4 direcoes(falta animacao) 
            if (xAngle < 45f)
            {
                //direita
                _anim.SetInteger("Direction", 1);
                velocity2 = new Vector2(1, 0);
            }
            else if (xAngle < 135f)
            {
                //cima
                if (yAngle < 90)
                {
                    _anim.SetInteger("Direction", 0);
                    velocity2 = new Vector2(0, 1);
                }
                //baixo
                else
                {
                    _anim.SetInteger("Direction", 2);
                    velocity2 = new Vector2(0, -1);
                }
            }
            else
            {
                //esquerda
                _anim.SetInteger("Direction", 3);
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



    

    void FixedUpdate()
    {
        //comeca perseguir o player
        if (isHear && !isActive)
        {
            StartMove();
        }

        //enquanto persegue o player
        if (isActive && !isStop)
        {
            float playerDistance = ((Vector2)player.transform.position - (Vector2)this.transform.position).magnitude;
            if (playerDistance < attackRange)
            {
                ReachPlayer();
            }

            else
            {
                MoveManequim();
            }
        }
        //comeca a voltar para local original(depois de esperar um pouco o Player)
        if (playerCollision.IsHidden() && isActive)
        {
            StartBack();
        }
        
        //enquanto espera o player escondido
        if(isWaiting)
        {
            WaitPlayer();
        }

        //enquanto volta
        if (isBack && !isStop)
        {
            MoveManequim();

            if (reachedEndOfPath) StopBack();
        }

        //reseta o isHear todas as vezes
        if (isHear) isHear = false;
    }



    //funcoes para ir para o player
    #region //Start Move
    private void StartMove()
    {
        _anim.SetBool("isWalking", true);
        sprite.color = new Color(0, 1, 0, 1);
        isActive = true;
        isStop = true;
        isBack = false;
        speed = chaseSpeed;
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

    #region //Stop Move
    void StopMove()
    {
        _anim.SetBool("isWalking", false);
        isActive = false;
        isStop = true;
        //faz animacao
        sprite.color = new Color(1, 1, 1, 1);
    }
    #endregion


    //funcoes para voltar
    #region//StartBack
    private void StartBack()
    {
        sprite.color = new Color(1, 0.5f, 0, 1);

        isWaiting = true;
        isStop = true;
    }

    private void WaitPlayer()
    {
        if (!playerCollision.IsHidden())
        {
            waitTime = 0;
            isWaiting = false;
            isStop = false;
            sprite.color = new Color(1, 0, 0, 1);
        }

        if (waitTime >= 3f)
        {
            waitTime = 0;
            isWaiting = false;
            StopMove();
            isStop = false;
            isBack = true;
            PathUpdate();
            speed = backSpeed;
            sprite.color = new Color(0, 0.5f, 1, 1);
        }

        waitTime += Time.deltaTime;
    }
    #endregion

    #region//StopBack
    private void StopBack()
    {
        isBack = false;
        isStop = true;
        //faz animacao
        sprite.color = new Color(1, 1, 1, 1);
    }
    #endregion


    //funcoes para detectar som
    #region //Som
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sound"))
            isHear = true;
    }
    #endregion
}