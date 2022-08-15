using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueColliderSc : MonoBehaviour
{
    [SerializeField] private GameObject textCanvas;
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] private List<string> listDialogue;

    private bool isActive;
    private int textNumber;
    private int dialogueLenght;
    private Text text;

    private void Start()
    {
        isActive = false;
        textCanvas.SetActive(false);
        textNumber = 0;

        text = textCanvas.transform.Find("Text").gameObject.GetComponent<Text>();
        dialogueLenght = listDialogue.Count;

        text.text = listDialogue[0];
    }

    public void StartText()
    {
        isActive = true;
        Time.timeScale = 0;
        textCanvas.SetActive(true);
    }

    public void EndText()
    {
        isActive = false;
        Time.timeScale = 1;
        textCanvas.SetActive(false);
        textNumber = 0;
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndText();
        }

        if (isActive && Input.GetMouseButtonDown(0))
        {
            textNumber++;
            if (textNumber >= dialogueLenght)
            {
                EndText();
            }

            text.text = listDialogue[textNumber];
        }
    }

    /*    StartText();

        //verifica se pauseMenu foi colocado no inspector
        if (pauseMenu == null)
        {
            Debug.Log("PauseMenu not found");
            return;
        }

        //muda o variavel do pause menu
        pauseMenu.isGamePaused = true;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isActive)
        {
            StartText();

            //verifica se pauseMenu foi colocado no inspector
            if (pauseMenu == null)
            {
                Debug.Log("PauseMenu not found");
                return;
            }

            //muda o variavel do pause menu
            pauseMenu.isGamePaused = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActive)
        {
            StartText();

            //verifica se pauseMenu foi colocado no inspector
            if (pauseMenu == null)
            {
                Debug.Log("PauseMenu not found");
                return;
            }

            //muda o variavel do pause menu
            pauseMenu.isGamePaused = true;
        }
    }


}
