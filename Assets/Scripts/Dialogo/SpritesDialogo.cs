using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritesDialogo : MonoBehaviour
{
    public Dictionary<string, Sprite> spriteDialogo = new Dictionary<string, Sprite>();

    [SerializeField] Sprite personagemPrincipal;
    [SerializeField] Sprite velho;

    private void Awake()
    {
        spriteDialogo.Add("jogador", personagemPrincipal);
        spriteDialogo.Add("veio", velho);
    }
}
