using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cuida da vida do Player

//Script relacionado: Detect_Collision(Objeto: Player_Damage)
//                    BarraDeVida(Objeto: HP)
public class Vida : MonoBehaviour
{
    //parametros de vida
    [SerializeField] int vidaMax;
    [HideInInspector] public int vidaAtual;

    //objetos externos
    BarraDeVida barraScript;
    SpriteRenderer sprite;
    private Detect_Collision damageCol;

    //parametros de dano
    [SerializeField] float invencibleTime;
    [SerializeField] private float blinkPeriod;
    private float invencibleTimer;
    private bool canHit = true;

    void Start()
    {
        //pega objetos externos
        GameObject hp = GameObject.Find("UI_Jogador/HP");
        barraScript = hp.GetComponent<BarraDeVida>();

        damageCol = transform.Find("Player_Damage").gameObject.
                GetComponent<Detect_Collision>();

        sprite = GetComponent<SpriteRenderer>();

        //inicializa a vida
        vidaAtual = vidaMax;
        barraScript.DefinirVidaMax(vidaMax);
    }

    void Update()
    {
        if(damageCol.isEnemyHit && canHit)
        {
            //recebe dano
            Dano(damageCol.attackDamage);

            //inicializa dados para piscar
            canHit = false;
            invencibleTimer = 0;            
        }

        if(!canHit)
        {
            Piscar();
        }

        barraScript.DefinirVida(vidaAtual);
    }

    //funcao para piscar
    void Piscar()
    {
        //pisca
        var repeatValue = Mathf.Repeat(invencibleTimer, blinkPeriod);
        sprite.enabled = repeatValue >= blinkPeriod * 0.5f;

        //condicao de termino
        if (invencibleTimer >= invencibleTime)
        {
            canHit = true;
            sprite.enabled = true;
        }
            

        invencibleTimer += Time.deltaTime;
    }


    //funcao para receber dano
    public void Dano(int _dano)
    {
        Debug.Log(vidaAtual);
        Debug.Log(vidaMax);
        vidaAtual = Mathf.Clamp(vidaAtual-_dano, 0, vidaMax);

        barraScript.DefinirVida(vidaAtual);

        if (vidaAtual == 0)
        {
            // morte
            Destroy(gameObject);
        }
    }
}
