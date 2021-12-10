using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;

    ItemSO item;

    public void AddItem(ItemSO newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
