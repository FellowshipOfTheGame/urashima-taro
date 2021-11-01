using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Utilizacao
//Coloca true nos que voce quer salvar
//Chame a funcao SavePlayer quando quer salvar os dados
//e a funcao LoadPlayer quando quer carregar os dados


//Funcionamento
//SceneSaveVariables - pega todos variaveis que quer salvar do player
//                    - SaveScene - junta e manda dados para SaveSystem
//                    - LoadScene - pega dados do SaveSystem e coloca em outros Scripts
//
//SaveSystem - SaveScene - pega dados da cena e coloca num file(para conseguir salvar)
//           - LoadScene - pega dados do file e da o retorno
//
//SceneData - funciona tipo um variavel(eu acho), que contem todos tipos de dados que quer salvar

public class SceneSaveVariables : MonoBehaviour
{
    //quando adicionar algum variavel, pode tirar esse texto e as variaveis para teste


    //bools(serao falsos caso nao quer salvar variavel nessa cena)
    [Header("Parametros que vao ser salvos")]
    public bool isSaveTestPos;

    //variaveis que precisam ser salvos
    [HideInInspector] public float[] testPos;


    //pega Componentes
    private GameObject saveObj;
    private void Start()
    {
        if(isSaveTestPos)
            saveObj = GameObject.Find("SaveTestObj");
    }


    //pega os variaveis de outros scripts
    //e manda o Script SaveSystem salvar as variaveis
    public void SaveScene()
    {
        //parametros teste
        testPos = new float[3];
        if (isSaveTestPos)
        {
            testPos[0] = saveObj.transform.position.x;
            testPos[1] = saveObj.transform.position.y;
            testPos[2] = saveObj.transform.position.z;
        }
        else testPos = null;
        

        //manda dados para SaveSystem
        SaveSystem.SaveScene(this);
    }


    //pega dados salvos e coloca em cada Script
    public void LoadScene()
    {
        //pega dados do SaveSystem
        SceneData data = SaveSystem.LoadScene();

        //parametros teste
        if(isSaveTestPos)
        {
            Vector3 position;
            position.x = data.testPos[0];
            position.y = data.testPos[1];
            position.z = data.testPos[2];
            saveObj.transform.position = position;
        }
    }
}
