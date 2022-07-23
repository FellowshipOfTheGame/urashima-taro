using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;

    ItemSO item;
    private TextMeshProUGUI quantityText;
    public float iconSize;

    // Sprite with size 251x251 used as example to resize sprites (kame)
    private const float exempleWidth = 251f;
    private const float exempleHeight = 251f;
    private const float sizeFactor = 0.25f;

    private void Start()
    {
        quantityText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void ResizeSprite()
    {
        float originalWidth = icon.preferredWidth;
        float originalHeight = icon.preferredHeight;
        float widthFactor = iconSize * exempleWidth * sizeFactor / originalWidth;
        float heightFactor = iconSize * exempleHeight * sizeFactor / originalHeight;
        icon.rectTransform.sizeDelta = new Vector2(widthFactor * originalWidth, heightFactor*originalHeight);
        Debug.Log(widthFactor);
    }

    public void AddItem(ItemSO newItem)
    {
        item = newItem;
        icon.sprite = item.icon;

        ResizeSprite();

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
