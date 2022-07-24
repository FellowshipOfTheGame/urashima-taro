using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script is used to teleport the Player using collision
 * (to another scene position or some position in the same scene)
 * The player object needs to have the Tag "Player".
 */
public class CollisionTeleport : MonoBehaviour
{
    //posicao de destino
    [SerializeField] Vector3 destinyPosition;
    //cena para onde ir (se nao colocar nada nao muda de cena)
    [SerializeField] string scene = null;

    private Fade fade;

    private bool changeScene = false;

    private void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Fade>();
        if(fade == null)
        {
            Debug.LogWarning("Verifique se o nome do componente de fade e `Fade`");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject player = col.gameObject;
        if (player.tag == "Player")
        {
            //se o teleporte for na cena atual, so teleporta
            if (scene == null || scene == "" || scene == SceneManager.GetActiveScene().name)
            {
                player.transform.position = destinyPosition;
            }
            //se o teleporte for na outra cena, carrega outra cena
            else
            {
                TeleportManager.instance.teleportPos = destinyPosition;
                changeScene = true;
                fade.StartFadeOut();
            }
        }
    }


    private void Update()
    {
        if(changeScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene(scene);
        }
    }
}
