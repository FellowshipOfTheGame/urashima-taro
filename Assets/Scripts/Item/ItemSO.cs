using UnityEngine;

public enum Type 
{
    Default,
    Weapon
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    new public string name = "New Item";
    public Type type;
    public Sprite icon = null;
    public int ID;
    public int quantity = 0;
    public GameObject item;
}
