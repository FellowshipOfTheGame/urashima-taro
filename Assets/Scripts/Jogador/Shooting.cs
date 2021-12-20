using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// TODO: Mudar shoot e reload do ChangeWeapons.cs para Shooting.cs

public class Shooting : MonoBehaviour
{
    private AudioManager audioManager;
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
        audioManager = FindObjectOfType<AudioManager>();
        GameObject txt = GameObject.Find("UI_Jogador/DisplayBalas");

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
    }

    public void Atirar()
    {
        if (!melee)
        {
            if (tirosAtuais > 0 && delay <= 0f && podeAtirar)
            {
                audioManager.Play("PISTOL_SHOOT");
                GameObject bala = Instantiate(balaPrefab, pontoDeTiro.position, pontoDeTiro.rotation);
                Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
                rb.AddForce(pontoDeTiro.up * forcaBala, ForceMode2D.Impulse);

                tirosAtuais--;
                delay = cooldownTiros;
            }
        }
        else
        {
            if(delay <= 0f)
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
        if(!melee)
            StartCoroutine(Recarregar());
    }

    private IEnumerator Recarregar()
    {
        audioManager.Play("PISTOL_RELOAD_FAST");
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
