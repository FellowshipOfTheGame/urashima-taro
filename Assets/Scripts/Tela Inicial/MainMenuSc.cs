using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSc : MonoBehaviour
{
    [SerializeField] AudioManager audio;
    private string nomeMusica = "MenuTheme";

    public void Start()
    {
        audio.Play(nomeMusica);
    }

    public void PlayButtonPressed()
    {
        //Colocado para teste
        SceneManager.LoadScene("HerbertH2");
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
