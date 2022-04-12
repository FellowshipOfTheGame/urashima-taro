using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Melee : MonoBehaviour
{
    [SerializeField] Transform pontoDeTiro;

    TextMeshProUGUI displayBalas;

    [SerializeField] float cooldownTiros;
    float delay;

    [SerializeField] float range;

    [SerializeField] LayerMask inimigo;

    void Start()
    {
        GameObject txt = GameObject.Find("UI/UI_Jogador/DisplayBalas");

        displayBalas = txt.GetComponent<TextMeshProUGUI>();
        delay = cooldownTiros;
    }

    // Update is called once per frame
    void Update()
    {
        displayBalas.SetText("");

        if (delay >= 0f)
            delay -= Time.deltaTime;

        Atirar();
    }

    private void Atirar()
    {
        if (delay <= 0f && InputManager.GetInstance().GetShootPressed())
        {
            Debug.Log("Aq");
            Collider2D[] dano = Physics2D.OverlapCircleAll(pontoDeTiro.position, range, inimigo);

            for (int i = 0; i < dano.Length; i++)
            {
                Destroy(dano[i].gameObject);
            }

            delay = cooldownTiros;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoDeTiro.position, range);
    }
}
