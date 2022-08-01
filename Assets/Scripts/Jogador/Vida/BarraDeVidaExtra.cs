using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaExtra : MonoBehaviour
{
    [SerializeField] GameObject sliderObj;
    private Slider slider;
    [SerializeField] GameObject backGround;
    [SerializeField] float inicialFill;

    int vidaExtraInit = 5;
    RectTransform sliderTrans;
    RectTransform backTrans;
    Vector2 sliderInitSize;
    Vector3 sliderInitPos;
    Vector2 backInitSize;
    [SerializeField] Vector2 sliderZeroSize;
    [SerializeField] Vector3 sliderZeroPos;
    [SerializeField] Vector2 backZeroSize;

    public void Start()
    {
        slider = sliderObj.GetComponent<Slider>();

        sliderTrans = sliderObj.GetComponent<RectTransform>();
        backTrans = backGround.GetComponent<RectTransform>();

        sliderInitSize = sliderTrans.sizeDelta;
        backInitSize = backTrans.sizeDelta;
        sliderInitPos = sliderTrans.anchoredPosition;

        backGround.SetActive(false);
        slider.value = 0;
    }

    public void DefinirVidaMax(int vida)
    {
        //define slider
        slider.maxValue = vida;
        slider.value = inicialFill * slider.maxValue + vida * (1 - inicialFill);

        float posX = (((sliderInitPos.x - sliderZeroPos.x) / vidaExtraInit) * vida) + sliderZeroPos.x;
        sliderTrans.anchoredPosition = new Vector2(posX, sliderTrans.anchoredPosition.y);

        float width = ((sliderInitSize.x - sliderZeroSize.x) / vidaExtraInit * vida) + sliderZeroSize.x;
        sliderTrans.sizeDelta = new Vector2(width, sliderTrans.sizeDelta.y);

        //define backGround
        backGround.SetActive(true);
        width = ((backInitSize.x - backZeroSize.x) / vidaExtraInit * vida) + backZeroSize.x;
        backTrans.sizeDelta = new Vector2(width, backTrans.sizeDelta.y);


    }
    public void DefinirVida(int vida)
    {
        //define slider
        slider.value = inicialFill * slider.maxValue + vida * (1 - inicialFill);

        //define backGround
        if (vida <= 0) backGround.SetActive(false);

    }
}
