using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameTheme : MonoBehaviour
{
    [SerializeField] AudioManager audio;
    private string nomeMusica = "Intro_Gameplay_Music";
    
    // Start is called before the first frame update
    void Start()
    {
        audio.Play(nomeMusica);

        nomeMusica = "Loop_Gameplay_Music";

        audio.Play(nomeMusica);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
