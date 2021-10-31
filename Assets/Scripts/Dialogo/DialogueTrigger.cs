using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] TextAsset inkJSON;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            DialogueManager.GetInstance().ComecoDialogo(inkJSON);
            InputManager.GetInstance().ChangeActionMap("Dialogo");
        }
    }
}
