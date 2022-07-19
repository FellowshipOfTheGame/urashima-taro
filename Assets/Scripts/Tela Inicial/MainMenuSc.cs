using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSc : MonoBehaviour
{
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
