using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// TODO: Dividir esse script em 2: um para melee e outro para ranged

public class Shooting : MonoBehaviour
{
    [SerializeField] bool melee;

    [Header("Variaveis ranged & melee")]
    [SerializeField] Transform pontoDeTiro;

    TextMeshProUGUI displayBalas;

    [SerializeField] float cooldownTiros;
    float delay;

    [Header("Variaveis ranged")]
    [SerializeField] GameObject balaPrefab;

    [SerializeField] float forcaBala;

    [SerializeField] int tirosMax;
    [HideInInspector] public int tirosAtuais;

    public bool podeAtirar = true;

    [Header("Variaveis melee")]
    [SerializeField] float range;

    [SerializeField] LayerMask inimigo;

    void Start()
    {
        GameObject txt = GameObject.Find("UI/UI_Jogador/DisplayBalas");

        displayBalas = txt.GetComponent<TextMeshProUGUI>();
        tirosAtuais = tirosMax;
        delay = cooldownTiros;
    }

    void Update()
    {
        if (!melee)
            displayBalas.SetText(tirosAtuais.ToString());
        else
            displayBalas.SetText("");

        if (delay >= 0f)
            delay -= Time.deltaTime;

        Atirar();
        Reload();
    }

    public void Atirar()
    {
        if (!melee)
        {
            if (tirosAtuais > 0 && delay <= 0f && podeAtirar && InputManager.GetInstance().GetShootPressed())
            {
                GameObject bala = Instantiate(balaPrefab, pontoDeTiro.position, pontoDeTiro.rotation);
                Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
                rb.AddForce(pontoDeTiro.up * forcaBala, ForceMode2D.Impulse);

                tirosAtuais--;
                delay = cooldownTiros;
            }
        }
        else
        {
            if(delay <= 0f && InputManager.GetInstance().GetShootPressed())
            {
                Collider2D[] dano = Physics2D.OverlapCircleAll(pontoDeTiro.position, range, inimigo);

                for (int i = 0; i < dano.Length; i++)
                {
                    Destroy(dano[i].gameObject);
                }

                delay = cooldownTiros;
            }
        }
    }



    public void Reload()
    {
        if(!melee && InputManager.GetInstance().GetReloadPressed())
            StartCoroutine(Recarregar());
    }

    private IEnumerator Recarregar()
    {
        podeAtirar = false;
        yield return new WaitForSeconds(1f);
        tirosAtuais = tirosMax;
        podeAtirar = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoDeTiro.position, range);
    }
}
