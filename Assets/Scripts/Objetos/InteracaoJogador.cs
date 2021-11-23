using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteracaoJogador : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private float raioInteracao;
    [SerializeField] private LayerMask objeto;
    [SerializeField] private TextMeshProUGUI texto;
    private bool interagindo = false;
    Collider2D maisPerto = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetectarObjetos();
        AcessarInteracao();
    }

    private void AcessarInteracao()
    {
        if(maisPerto != null)
        {
            Interactable interactable = maisPerto.gameObject.GetComponent<Interactable>();

            if(interactable != null)
            {
                if (!interagindo)
                {
                    interactable.Acender();
                }
                texto.text = interactable.Descricao();
                if (InputManager.GetInstance().GetInteragir())
                {
                    interactable.Interagir();
                    interagindo = !interagindo;
                }
            }
        }
        else
        {
            texto.text = "";
        }
    }

    private void DetectarObjetos() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(jogador.transform.position, raioInteracao, objeto);

        if (colliders.Length == 0)
        {
            if(maisPerto != null)
            {
                Interactable interactable = maisPerto.gameObject.GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Apagar();
                }
            }
            interagindo = false;
            maisPerto = null;
            return;
        }

        float minSqrDistancia = Mathf.Infinity;

        for (int i = 0; i < colliders.Length; i++)
        {
            float sqrDistanceToCenter = (jogador.transform.position - colliders[i].transform.position).sqrMagnitude;

            if (sqrDistanceToCenter < minSqrDistancia)
            {
                minSqrDistancia = sqrDistanceToCenter;
                if (maisPerto != null && maisPerto != colliders[i])
                {
                    Interactable interactable = maisPerto.gameObject.GetComponent<Interactable>();

                    if (interactable != null)
                    {
                        interactable.Apagar();
                    }
                }
                interagindo = false;
                maisPerto = colliders[i];
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(jogador.transform.position, raioInteracao);
    }
}
