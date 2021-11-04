using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    //variaveis da cena que deverao ser salvos
    [HideInInspector] public float[] testPos;

    //pega dados e junta no variavel tipo "SceneData"
    public SceneData(SceneSaveVariables scene)
    {
        //parametros teste
        testPos = scene.testPos;
    }
}