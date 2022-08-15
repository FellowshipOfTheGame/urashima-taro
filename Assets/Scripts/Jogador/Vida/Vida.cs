using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Cuida da vida do Player

//Script relacionado: Detect_Collision(Objeto: Player_Damage)
//                    BarraDeVida(Objeto: HP)
public class Vida : MonoBehaviour
{
    //parametros de vida
    [SerializeField] int vidaMax;
    [HideInInspector] public int vidaAtual;
    private int vidaExtraMax;
    [HideInInspector] public int vidaExtra;


    //objetos externos
    BarraDeVida barraScript;
    BarraDeVidaExtra barraExtraScript;
    SpriteRenderer sprite;
    private Detect_Collision damageCol;

    //parametros de dano
    [SerializeField] float invencibleTime;
    [SerializeField] private float blinkPeriod;
    private float invencibleTimer;
    private bool canHit = true;

    //posicao inicial
    Vector3 inicialPos;

    void Start()
    {
        //pega objetos externos
        GameObject hp = GameObject.Find("UI_Jogador/HP");
        barraScript = hp.GetComponent<BarraDeVida>();
        if (barraScript == null) Debug.Log("Barra de vida not found");

        GameObject hpExtra = GameObject.Find("UI_Jogador/HP/ExtraHP");
        barraExtraScript = hpExtra.GetComponent<BarraDeVidaExtra>();
        if (barraExtraScript == null) Debug.Log("Barra de vida extra not found");

        damageCol = transform.Find("Player_Damage").gameObject.
                GetComponent<Detect_Collision>();
        if (damageCol == null) Debug.Log("Detect_Collision not Found");

        sprite = GetComponent<SpriteRenderer>();

        //inicializa a vida
        vidaAtual = vidaMax;
        barraScript.DefinirVidaMax(vidaMax);

        //salva a posicao inicial
        inicialPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }

    void Update()
    {
        if (damageCol.isEnemyHit && canHit)
        {
            //recebe dano
            Dano(damageCol.attackDamage);

            //inicializa dados para piscar
            canHit = false;
            invencibleTimer = 0;

            barraScript.DefinirVida(vidaAtual);
        }

        if (!canHit)
        {
            Piscar();
        }
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
        //tira da vida extra
        if(vidaExtra != 0)
        {
            if(vidaExtra >= _dano)
            {
                vidaExtra -= _dano;
                _dano = 0;
            }
            else
            {
                _dano -= vidaExtra;
                vidaExtra = 0;
            }
            barraExtraScript.DefinirVida(vidaExtra);
        }

        //tira da vida normal
        vidaAtual = Mathf.Clamp(vidaAtual - _dano, 0, vidaMax);

        barraScript.DefinirVida(vidaAtual);

        if (vidaAtual == 0)
        {
            // morte
            vidaAtual = vidaMax;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            damageCol.isEnemyHit = false;
            canHit = true;
            sprite.enabled = true;
            this.gameObject.transform.position = inicialPos;
        }
    }


    public void RecuperaVida(int _vida)
    {
        vidaAtual = Mathf.Min(vidaMax, vidaAtual + _vida);
        barraScript.DefinirVida(vidaAtual);
    }


    public void SetVidaExtra(int _vidaExtra)
    {
        vidaExtraMax = _vidaExtra;
        vidaExtra = _vidaExtra;
        barraExtraScript.DefinirVidaMax(vidaExtraMax);
        barraExtraScript.DefinirVida(vidaExtra);
    }
}
