using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : Interactable
{
    [SerializeField] private GameObject textCanvas;
    [SerializeField] GameObject outline;
    [SerializeField] PauseMenu pauseMenu;

    public void StartText()
    {
        Time.timeScale = 0;
        textCanvas.SetActive(true);
    }

    public void EndText()
    {
        Time.timeScale = 1;
        textCanvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            EndText();
        }
    }

    public override string Descricao()
    {
        return "";
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
        StartText();

        //verifica se pauseMenu foi colocado no inspector
        if(pauseMenu == null)
        {
            Debug.Log("PauseMenu not found");
            return;
        }

        //muda o variavel do pause menu
        pauseMenu.isGamePaused = true;
    }
}
