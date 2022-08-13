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

    // acessa o objeto mais proximo dentro da range
    private void AcessarInteracao()
    {
        if(maisPerto != null)
        {
            Interactable interactable = maisPerto.gameObject.GetComponent<Interactable>();
            
            if(interactable != null && !interactable.EstahAtivo())
            {
                if (!interagindo)
                {
                    // highlight no objeto
                    interactable.Acender();
                }
                texto.text = interactable.Descricao();
                if (InputManager.GetInstance().GetInteragir())
                {
                    // ação
                    interactable.Interagir();
                    interagindo = !interagindo;
                }
            }
            else
            {
                texto.text = "";
            }
        }
        else
        {
            texto.text = "";
        }
    }

    // detecta o objeto mais proximo dentro da range
    private void DetectarObjetos() 
    {
        // array com todos os interagiveis
        Collider2D[] colliders = Physics2D.OverlapCircleAll(jogador.transform.position, raioInteracao, objeto);
        Debug.Log(colliders.Length);
        if (colliders.Length == 0)
        {
            if(maisPerto != null)
            {
                // acessa o objeto mais proximo
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
            // D^2 = x^2 + y^2
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
