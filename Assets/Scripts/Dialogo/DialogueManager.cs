using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;

// TODO: Botoes estao na ordem invertida. Ex: o botao 0 eh o botao de baixo. Por isso, eh necessario escrever as escolhas no ink de forma invertida.

public class DialogueManager : MonoBehaviour
{
    public GameObject caixaDeTexto;
    public Image sprite;

    static Story _story;
    public TextMeshProUGUI nome;
    public TextMeshProUGUI texto;

    [SerializeField] GameObject[] escolhas;
    TextMeshProUGUI[] escolhasTexto;

    private bool dialogoRodando;
    private bool fazendoEscolha = false;

    private const string SPRITE_TAG = "sprite";
    private const string FALANTE_TAG = "falante";
    private SpritesDialogo spriteScript;

    private static DialogueManager instance;

    private bool usingKey = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Mais de 1 dialogue manager");
        }
        else
        {
            instance = this;
        }

        spriteScript = GetComponent<SpritesDialogo>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogoRodando = false;
        caixaDeTexto.SetActive(false);

        escolhasTexto = new TextMeshProUGUI[escolhas.Length];
        int i = 0;
        foreach(GameObject escolha in escolhas)
        {
            escolhasTexto[i] = escolha.GetComponentInChildren<TextMeshProUGUI>();
            escolhas[i].SetActive(false);
            i++;
        }

    }

    private void Update()
    {
        bool avancarDialogo = InputManager.GetInstance().GetAvancarDialogo();

        if (!dialogoRodando)
        {
            return;
        }

        if(avancarDialogo && !fazendoEscolha)
        {
            ContinuarHistoria();
        }

        if(fazendoEscolha)
        {
            MudancaControle();
        }
    }

    private void MudancaControle()
    {
        // detecta se o jogador esta usando o mouse e age de acordo

        if (InputManager.GetInstance().CurrentControlScheme() == "Keyboard")
        {
            if (InputManager.GetInstance().GetMousePos().x != 0 || InputManager.GetInstance().GetMousePos().y != 0)
            {
                usingKey = false;
                EventSystem.current.SetSelectedGameObject(null);
                return;
            }

            if (InputManager.GetInstance().GetMoveDialogo().y != 0)
            {
                if (!usingKey)
                {
                    StartCoroutine(PrimeiraEscolha());
                }

                usingKey = true;
                return;
            }
        }
        else if(!usingKey)
        {
            usingKey = true;
            StartCoroutine(PrimeiraEscolha());
        }
    }

    public void ComecoDialogo(TextAsset inkJSON)
    {
        _story = new Story(inkJSON.text);
        dialogoRodando = true;
        caixaDeTexto.SetActive(true);
        Time.timeScale = 0;

        ContinuarHistoria();
    }

    public void TerminoDialogo()
    {
        dialogoRodando = false;
        caixaDeTexto.SetActive(false);
        texto.text = "";
        Time.timeScale = 1;

        InputManager.GetInstance().ChangeActionMap("Player_base");
    }

    private void ContinuarHistoria()
    {
        if (_story.canContinue)
        {
            texto.text = _story.Continue();

            MostrarEscolhas();

            Tags(_story.currentTags);
        }
        else
        {
            TerminoDialogo();
        }
    }

    private void Tags(List<string> tags)
    {
        foreach(string tag in tags)
        {
            string[] tagDividida = tag.Split(':');

            if(tagDividida.Length != 2)
            {
                Debug.LogError("Tag escrita incorretamente: " + tag);
            }

            string tagKey = tagDividida[0].Trim();
            string tagValor = tagDividida[1].Trim();

            switch(tagKey)
            {
                case SPRITE_TAG:
                    sprite.sprite = spriteScript.spriteDialogo[tagValor];
                    break;
                case FALANTE_TAG:
                    switch (tagValor)
                    {
                        case "nomeJogador":
                            nome.text = (string)_story.variablesState["nomeAtual"];
                            break;
                        default:
                            nome.text = tagValor;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }



    }

    private void MostrarEscolhas()
    {
        List<Choice> escolhasAtuais = _story.currentChoices;

        if(escolhasAtuais.Count == 0)
        {
            fazendoEscolha = false;
            return;
        }

        fazendoEscolha = true;

        int index = 0;

        foreach(Choice escolha in escolhasAtuais)
        {
            escolhas[index].SetActive(true);
            escolhasTexto[index].text = escolha.text;
            index++;
        }

        for(int i = index; i < escolhas.Length; i++)
        {
            escolhas[index].SetActive(false);
        }
    }

    private IEnumerator PrimeiraEscolha()
    {
        // caso nao use o mouse, a caixa selecionada eh a 0
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(escolhas[0]);
    }

    public void FazerEscolha(int escolha)
    {
        _story.ChooseChoiceIndex(escolha);
        EventSystem.current.SetSelectedGameObject(null);
        DesativarEscolhas();

        // Permite tirar a caixa de texto 'fantasma' qndo usa o mouse
        if (InputManager.GetInstance().CurrentControlScheme() == "Keyboard")
        {
            if(!usingKey)
                ContinuarHistoria();
        }

        usingKey = false;
        fazendoEscolha = false;
    }

    void DesativarEscolhas()
    {
        for (int i = 0; i < escolhas.Length; i++)
        {
            escolhas[i].SetActive(false);
        }

        // tira a caixa vazia caso a escolha seja marcada com +
        if (_story.currentText == "\n")
        {
            ContinuarHistoria();
        }
    }
}
