using UnityEngine;

public enum ItemType
{
    Weapon,
    Consumable,
    Armor
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public int ID;
    new public string name = "New Item";
    public ItemType type;
    public Sprite icon = null;
    public int quantity;
    public int quantityRedusedByUse;

    public int lifeHealed;                  // For consumable 

    public int lifeArmor;                   // For armor

    public GameObject itemPrefab;                 // Place the gameobject where the script of the item is 
}