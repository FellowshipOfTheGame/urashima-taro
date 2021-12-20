using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;

    ItemSO item;
    private TextMeshProUGUI quantityText;
    private void Start()
    {
        quantityText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddItem(ItemSO newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        quantityText.text = item.quantity.ToString();
    }

    // Maybe this function can be usefull latter
    public void UpdateQuantity()
    {
        quantityText.text = (item.quantity).ToString();
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        if(quantityText != null)
            quantityText.text = "";
    }
}
