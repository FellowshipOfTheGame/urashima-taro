using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// O que faz:
///     Controla Volume dos Audios
/// Como usar:
/// -Colocar os componentes
///     Audio: __audio
///     Principal: Slider do volume principal
///     Efeito: Slider do SFX
///     Musica: Slider da musica
///     Musicas: Nome dos sons que sao classificados como musica. (Ver os nomes no __audio)
/// </summary>

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioManager audio;
    [SerializeField] Slider principal;
    [SerializeField] Slider efeito;
    [SerializeField] Slider musica;
    [SerializeField] string[] musicas;


    void Update()
    {
        //se for musica, pega os valores do principal e musica como referencia
        //se nao, pega os valores do principal e efeito como referencia
        foreach (Sound s in audio.sounds)
        {
            if(Array.Exists(musicas, x => x == s.name))
                s.source.volume = principal.value * musica.value;
            else
                s.source.volume = principal.value * efeito.value;

        }
    }
}
