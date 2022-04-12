using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : MonoBehaviour
{
    [SerializeField] Transform pontoDeTiro;

    TextMeshProUGUI displayBalas;

    [SerializeField] float cooldownTiros;
    float delay;

    [SerializeField] GameObject balaPrefab;

    [SerializeField] float forcaBala;

    [SerializeField] int tirosMax;
    [HideInInspector] public int tirosAtuais;

    public bool podeAtirar = true;

    void Start()
    {
        GameObject txt = GameObject.Find("UI/UI_Jogador/DisplayBalas");

        displayBalas = txt.GetComponent<TextMeshProUGUI>();
        delay = cooldownTiros;
        tirosAtuais = tirosMax;
    }

    void Update()
    {
        displayBalas.SetText(tirosAtuais.ToString());

        if (delay >= 0f)
            delay -= Time.deltaTime;

        Atirar();
        Reload();
    }

    private void Atirar()
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

    private void Reload()
    {
        if (InputManager.GetInstance().GetReloadPressed())
            StartCoroutine(Recarregar());
    }

    private IEnumerator Recarregar()
    {
        podeAtirar = false;
        yield return new WaitForSeconds(1f);
        tirosAtuais = tirosMax;
        podeAtirar = true;
    }
}
