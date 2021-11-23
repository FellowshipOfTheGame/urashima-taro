using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract string Descricao();
    public abstract void Acender();
    public abstract void Apagar();
    public abstract void Interagir();
}
