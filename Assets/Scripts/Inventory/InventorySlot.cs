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

    private Vector2 posiMouse;
    private Vector2 posiObjeto;
    private float r = 50f;

    private void Start()
    {        
        quantityText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Tests if the slot was selected by mouse
        if (Input.GetMouseButtonDown(0))
        {
            if (item != null)
            {
                posiObjeto = (Vector2)this.gameObject.transform.position;
                posiMouse = (Vector2)Input.mousePosition;

                // Checks if the player clicked inside this slot square
                if (HasSelectedThisSlot(posiObjeto.x, posiObjeto.y, posiMouse.x, posiMouse.y, r))
                {
                    Debug.Log(item.name);
                }
            }
        }
    }

    private bool HasSelectedThisSlot(float m, float n, float x, float y, float r)
    {
        if (-r <= (x - m) && (x - m) <= r &&
           (-r <= (y - n) && (y - n) <= r))
            return true;
        return false;
    }

    private void ResizeSprite()
    {
        float originalWidth = icon.preferredWidth;
        float originalHeight = icon.preferredHeight;
        float widthFactor = iconSize * exempleWidth * sizeFactor / originalWidth;
        float heightFactor = iconSize * exempleHeight * sizeFactor / originalHeight;
        icon.rectTransform.sizeDelta = new Vector2(widthFactor * originalWidth, heightFactor*originalHeight);
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
