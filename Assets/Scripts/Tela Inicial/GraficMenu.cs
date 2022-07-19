using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraficMenu : MonoBehaviour
{
    [SerializeField] Dropdown drop;
    [SerializeField] int[] resolutionX;
    [SerializeField] int[] resolutionY;

    int dropIndex;
    string resulKey = "resolution";

    private void Start()
    {
        //carrega a resolucao 
        if (!PlayerPrefs.HasKey(resulKey))
        {
            PlayerPrefs.SetInt(resulKey, resolutionX.Length - 1);
        }
        else
        {
            dropIndex = PlayerPrefs.GetInt(resulKey, 0);
            drop.value = dropIndex;
        }
    }

    void Update()
    {
        if (dropIndex != drop.value)
        {
            //muda resolucao
            ChangeResolution();
            dropIndex = drop.value;

            //salva
            PlayerPrefs.SetInt(resulKey, dropIndex);
        }

    }

    //muda a resolução
    //só dá para no Build
    void ChangeResolution()
    {
        Screen.SetResolution(resolutionX[drop.value], resolutionY[drop.value], false, 60);
    }
}
