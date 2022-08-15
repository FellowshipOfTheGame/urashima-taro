using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemTeleport : Interactable
{
    //posicao de destino
    [SerializeField] Vector3 destinyPosition;
    //cena para onde ir (se nao colocar nada nao muda de cena)
    [SerializeField] string scene = null;
    [SerializeField] GameObject outline;

    private Fade fade;
    private bool isActive = false;

    private bool changeScene = false;

    private void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Fade>();
        if (fade == null)
        {
            Debug.LogWarning("Verifique se o nome do componente de fade e `Fade`");
        }
    }

    private void Update()
    {
        if (changeScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene(scene);
        }
    }

    public override string Descricao()
    {
        return "Pressione E para teleportar";
    }

    public override void Acender()
    {
        outline.SetActive(true);
    }

    public override void Apagar()
    {
        outline.SetActive(false);
    }

    public override void Interagir()
    {
        isActive = true;

        //se o teleporte for na cena atual, so teleporta
        if (scene == null || scene == "" || scene == SceneManager.GetActiveScene().name)
        {
            GameObject player = GameObject.Find("Jogador 1");
            player.transform.position = destinyPosition;
            isActive = false;
        }
        //se o teleporte for na outra cena, carrega outra cena
        else
        {
            TeleportManager.instance.teleportPos = destinyPosition;
            changeScene = true;
            fade.StartFadeOut();
        }
    }

    public override bool EstahAtivo()
    {
        return isActive;
    }
}
