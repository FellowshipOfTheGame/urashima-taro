using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controla o HUD de sanidade

//Scripts relacionados Detect_Collision(Objeto: EnemySearch)
public class SanityControl : MonoBehaviour
{
    //sprites para animacao
    [SerializeField] Texture[] sprites;

    //velocidade das frames
    [SerializeField] float normalSpeed;
    [SerializeField] float aceleratedSpeed;

    //objetos externos
    [SerializeField] Detect_Collision enemySearcher; //Objeto EnemySearch do Jogador

    private RawImage image;

    private int frameCounter;
    private int maxFrame;
    private float timer;
    private float maxTime;

    void Start()
    {
        image = GetComponent<RawImage>();

        maxFrame = sprites.Length;
    }



    void Update()
    {
        AtualizeFrame();
    }

    void AtualizeFrame()
    {
        if (enemySearcher.isEnemyHit)
            maxTime = aceleratedSpeed;
        else
            maxTime = normalSpeed;

        if (timer >= maxTime)
        {
            timer = 0;
            frameCounter = (frameCounter + 1) % maxFrame;
            image.texture = sprites[frameCounter];
        }
        timer += Time.deltaTime;
    }
}
