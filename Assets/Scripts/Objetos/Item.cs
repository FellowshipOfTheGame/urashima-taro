using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    [SerializeField] GameObject outline;

    [SerializeField] ItemSO item;

    public override string Descricao()
    {
        return "Pressione E para pegar o item";
    }

    public override void Acender()
    {
        outline.SetActive(true);
    }

    public override void Apagar()
    {
        outline.SetActive(false);
    }

    public override void Interagir()
    {
        // interacao com item (text box, adicionar ao inventario, etc.)
        Inventory.GetInstance().AddInventory(item);

        gameObject.SetActive(false);
    }

    public override bool EstahAtivo()
    {
        return false;
    }
}
