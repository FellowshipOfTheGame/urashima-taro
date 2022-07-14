using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInput : MonoBehaviour
{
    public PlayerInput pInput;

    [SerializeField] float velocidadeMovimento;

    [SerializeField] SpriteRenderer sprite;

    [SerializeField] CircleCollider2D raioSom;

    [SerializeField] GameObject lanterna;
    [SerializeField] Transform[] posicoesLanterna;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;

    [SerializeField] float runSpeedFactor;

    [HideInInspector] public bool isRunning = false;
    bool isLanternaOn = true;

    [SerializeField] private Transform armas;

    private MousePosition mousePosition;
    Animator anim;

    Vector2 movimento;
    Vector2 mousePos;

    float angulo;

    private Vector2 RIGHT_DIRECTION = new Vector2(1.0f, 0.0f);
    private Vector2 LEFT_DIRECTION = new Vector2(-1.0f, 0.0f);
    private Vector2 UP_DIRECTION = new Vector2(0.0f, 1.0f);
    private Vector2 DOWN_DIRECTION = new Vector2(0.0f, -1.0f);
    private Vector2 UP_LEFT_DIRECTION = new Vector2(-0.7f, 0.7f);
    private Vector2 UP_RIGHT_DIRECTION = new Vector2(0.7f, 0.7f);
    private Vector2 DOWN_LEFT_DIRECTION = new Vector2(-0.7f, -0.7f);
    private Vector2 DOWN_RIGHT_DIRECTION = new Vector2(0.7f, -0.7f);
    private float distanceEpsilon = 0.1f; // To compare two vectors distance and check if they are approximately equal

    private void Start()
    {
        mousePosition = GameObject.Find("MousePosReader").GetComponent<MousePosition>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (movimento.x == 0f && movimento.y == 0f)
        {
            raioSom.radius = 0;
        }
        else if (!isRunning)
        {
            raioSom.radius = 1.7f;
        }
        else 
        {
            raioSom.radius = 6f;
        }
    }

    private void FixedUpdate()
    {
        angulo = mousePosition.angulo;
        //rb.rotation = angulo;

        Flip();
        //Rotation();
        Move();
        Run();
        Flashlight();
        RotationArmas();
        // Debug.Log(InputManager.GetInstance().GetMoveDirection());
    }

    private void Flip()
    {
        Vector2 playerMoveDirection = InputManager.GetInstance().GetMoveDirection();

        if (playerMoveDirection == UP_DIRECTION)
        {
            lanterna.transform.position = posicoesLanterna[0].position;
            anim.SetInteger("Direcao", 0);
        }
        else if (playerMoveDirection == DOWN_DIRECTION)
        {
            lanterna.transform.position = posicoesLanterna[2].position;
            anim.SetInteger("Direcao", 2);
        }
        else if (playerMoveDirection == RIGHT_DIRECTION)
        {
            lanterna.transform.position = posicoesLanterna[1].position;
            anim.SetInteger("Direcao", 1);
        }
        else if (playerMoveDirection == LEFT_DIRECTION)
        {
            lanterna.transform.position = posicoesLanterna[3].position;
            anim.SetInteger("Direcao", 3);
        }
        else if (Vector2.Distance(playerMoveDirection, UP_RIGHT_DIRECTION) < distanceEpsilon)
        {
            if ((angulo < 45 && angulo >= 0) || (angulo > -45 && angulo <= 0))
            {
                // cima
                lanterna.transform.position = posicoesLanterna[0].position;
                anim.SetInteger("Direcao", 0);
            }
            else if (angulo <= -45 && angulo >= -135)
            {
                // direita
                lanterna.transform.position = posicoesLanterna[1].position;
                anim.SetInteger("Direcao", 1);
            }
        }
        else if (Vector2.Distance(playerMoveDirection, UP_LEFT_DIRECTION) < distanceEpsilon)
        {
            if ((angulo < 45 && angulo >= 0) || (angulo > -45 && angulo <= 0))
            {
                // cima
                lanterna.transform.position = posicoesLanterna[0].position;
                anim.SetInteger("Direcao", 0);
            }
            else if ((angulo >= 45 && angulo <= 90) || (angulo >= -270 && angulo <= -225))
            {
                // esquerda
                lanterna.transform.position = posicoesLanterna[3].position;
                anim.SetInteger("Direcao", 3);
            }
        }
        else if (Vector2.Distance(playerMoveDirection, DOWN_RIGHT_DIRECTION) < distanceEpsilon)
        {
            if (angulo < -135 && angulo > -225)
            {
                // baixo
                lanterna.transform.position = posicoesLanterna[2].position;
                anim.SetInteger("Direcao", 2);
            }            
            else if (angulo <= -45 && angulo >= -135)
            {
                // direita
                lanterna.transform.position = posicoesLanterna[1].position;
                anim.SetInteger("Direcao", 1);
            }
        }
        else if (Vector2.Distance(playerMoveDirection, DOWN_LEFT_DIRECTION) < distanceEpsilon)
        {
            if (angulo < -135 && angulo > -225)
            {
                // baixo
                lanterna.transform.position = posicoesLanterna[2].position;
                anim.SetInteger("Direcao", 2);
            }
            else if ((angulo >= 45 && angulo <= 90) || (angulo >= -270 && angulo <= -225))
            {
                // esquerda
                lanterna.transform.position = posicoesLanterna[3].position;
                anim.SetInteger("Direcao", 3);
            }
        }
    }

    public void Rotation()
    {
        Vector2 inputVec = InputManager.GetInstance().GetRotation();

        if (InputManager.GetInstance().GetDevice() == "Mouse")
        {
            mousePos = cam.ScreenToWorldPoint(inputVec);
            inputVec = mousePos - rb.position;
        }

        angulo = Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angulo;
    }

    public void Move()
    {
        Vector2 inputVec = InputManager.GetInstance().GetMoveDirection();

        if(inputVec.x != 0 || inputVec.y != 0)
        {
            if(isRunning)
            {
                anim.SetBool("Correndo", true);
                anim.SetBool("Andando", false);
            }
            else
            {
                anim.SetBool("Andando", true);
                anim.SetBool("Correndo", false);
            }
        }
        else
        {
            anim.SetBool("Andando", false);
        }


        movimento = new Vector2(inputVec.x, inputVec.y);

        if (isRunning)
            rb.MovePosition(rb.position + runSpeedFactor * Time.fixedDeltaTime * velocidadeMovimento * movimento);
        else
            rb.MovePosition(rb.position + Time.fixedDeltaTime * velocidadeMovimento * movimento);
    }

    public void Run()
    {
        isRunning = InputManager.GetInstance().GetRunPressed();
    }

    public void Flashlight()
    {
        isLanternaOn = InputManager.GetInstance().GetLanternaPressed();

        lanterna.SetActive(isLanternaOn);
        if (lanterna.activeSelf)
        {
            lanterna.transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
    }

    private void RotationArmas()
    {
        armas.rotation = Quaternion.Euler(0, 0, angulo);
    }
}
