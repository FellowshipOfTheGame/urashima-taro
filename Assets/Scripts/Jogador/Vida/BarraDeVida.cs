using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float inicialFill;

    public void DefinirVidaMax(int vida)
    {
        slider.maxValue = vida;
        slider.value = inicialFill * slider.maxValue + vida * (1 - inicialFill);
    }
    public void DefinirVida(int vida)
    {
        slider.value = inicialFill * slider.maxValue + vida * (1 - inicialFill);
    }
}