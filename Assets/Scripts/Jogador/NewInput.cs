using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInput : MonoBehaviour
{
    [SerializeField] float velocidadeMovimento;

    [SerializeField] SpriteRenderer sprite;

    [SerializeField] CircleCollider2D raioSom;

    [SerializeField] GameObject lanterna;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;

    bool isRunning = false;
    bool isLanternaOn = true;

    Vector2 movimento;
    Vector2 mousePos;

    float angulo;

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
        if (isRunning)
            rb.MovePosition(rb.position + 2 * Time.fixedDeltaTime * velocidadeMovimento * movimento);
        else
            rb.MovePosition(rb.position + Time.fixedDeltaTime * velocidadeMovimento * movimento);

        rb.rotation = angulo;

        if ((angulo >= 0 && angulo < 22.5f) || (angulo <= 0 && angulo > -22.5f))
        {
            sprite.color = new Color(1, 0, 0, 1);
        }
        else if (angulo <= -22.5f && angulo > -67.5f)
        {
            sprite.color = new Color(0, 1, 0, 1);
        }
        else if (angulo <= -67.5f && angulo > -112.5f)
        {
            sprite.color = new Color(0, 0, 1, 1);
        }
        else if (angulo <= -112.5f && angulo > -157.5f)
        {
            sprite.color = new Color(1, 1, 0, 1);
        }
        else if (angulo <= -157.5f && angulo > -202.5)
        {
            sprite.color = new Color(1, 0, 1, 1);
        }
        else if (angulo <= -202.5f && angulo > -247.5)
        {
            sprite.color = new Color(0, 1, 1, 1);
        }
        else if ((angulo <= -247.5f && angulo >= -270)||(angulo >= 67.5f && angulo < 90))
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
        else if (angulo >= 22.5f && angulo < 67.5f)
        {
            sprite.color = new Color(0.2f, 0.5f, 1, 1);
        }
    }

    public void OnRotation(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        mousePos = cam.ScreenToWorldPoint(inputVec);

        Vector2 direcao = mousePos - rb.position;
        angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90f;
    }

    public void OnRotationGamepad(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();


        angulo = Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg - 90f;
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        movimento = new Vector2(inputVec.x, inputVec.y);
    }

    public void OnRun()
    {
        isRunning = !isRunning;
    }

    public void OnFlashlight()
    {
        isLanternaOn = !isLanternaOn;

        lanterna.SetActive(isLanternaOn);
    }
}