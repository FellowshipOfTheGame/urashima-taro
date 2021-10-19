using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapons : MonoBehaviour
{
    [SerializeField] GameObject[] armas;

    [SerializeField] GameObject[] menu;
    readonly SpriteRenderer[] spriteMenu = new SpriteRenderer[4];

    Shooting shootingScript;

    float tempoMenu = 0f;
    bool menuLigado = false;

    int armaAtual = 0;

    bool allNull = false;

    void Start()
    {
        for (int i = 0; i < 4; i++)
            spriteMenu[i] = menu[i].GetComponent<SpriteRenderer>();

        if (armas[0] != null)
            armaAtual = 0;
        else if (armas[1] != null)
            armaAtual = 1;
        else if (armas[2] != null)
            armaAtual = 2;
        else if (armas[3] != null)
            armaAtual = 3;
        else
            allNull = true;

        if (!allNull)
        {
            armas[armaAtual].SetActive(true);

            shootingScript = armas[armaAtual].GetComponent<Shooting>();
        }
    }

    private void Update()
    {
        if (tempoMenu >= 0f)
        {
            tempoMenu -= Time.deltaTime;
        }

        LigarMenu();
    }

    public void OnChangeWeapon(InputValue input)
    {
        if (!allNull)
        {
            Vector2 inputVec = input.Get<Vector2>();

            armas[armaAtual].SetActive(false);
            ResetColor(armaAtual);

            if (inputVec.y > 0)
            {
                armaAtual = (armaAtual + 1) % armas.Length;

                while (armas[armaAtual] == null)
                {
                    armaAtual = (armaAtual + 1) % armas.Length;
                }
            }
            else
            {
                if (armaAtual > 0)
                    armaAtual = (armaAtual - 1) % armas.Length;
                else
                    armaAtual = 3;

                while (armas[armaAtual] == null)
                {
                    if (armaAtual > 0)
                        armaAtual = (armaAtual - 1) % armas.Length;
                    else
                        armaAtual = 3;
                }
            }

            AtivarArma();
        }
    }

    public void OnShoot()
    {
        if(!allNull)
            shootingScript.Atirar();
    }

    public void OnReload()
    {
        if (!allNull)
            shootingScript.Reload();
    }

    public void OnArma1()
    {
        if(armas[0] != null)
        {
            armas[armaAtual].SetActive(false);
            ResetColor(armaAtual);

            armaAtual = 0;

            AtivarArma();
        }
    }

    public void OnArma2()
    {
        if (armas[1] != null)
        {
            armas[armaAtual].SetActive(false);
            ResetColor(armaAtual);

            armaAtual = 1;

            AtivarArma();
        }
    }

    public void OnArma3()
    {
        if (armas[2] != null)
        {
            armas[armaAtual].SetActive(false);
            ResetColor(armaAtual);

            armaAtual = 2;

            AtivarArma();
        }
    }

    public void OnArma4()
    {
        if (armas[3] != null)
        {
            armas[armaAtual].SetActive(false);
            ResetColor(armaAtual);

            armaAtual = 3;

            AtivarArma();
        }
    }

    void AtivarArma()
    {
        armas[armaAtual].SetActive(true);
        shootingScript = armas[armaAtual].GetComponent<Shooting>();
        shootingScript.podeAtirar = true;
        tempoMenu = 1f;
    }

    void LigarMenu()
    {
        if (tempoMenu >= 0f)
        {
            if (!menuLigado)
            {
                for (int i = 0; i < 4; i++)
                    menu[i].SetActive(true);
            }

            spriteMenu[armaAtual].color = new Color(0.735849f, 0.735849f, 0.735849f);
            menuLigado = true;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                ResetColor(i);
                menu[i].SetActive(false);
            }

            menuLigado = false;
        }
    }

    void ResetColor(int i)
    {
        spriteMenu[i].color = new Color(0.2941177f, 0.2941177f, 0.2941177f);
    }
}
