using UnityEngine;

public enum Tipe 
{
    Default,
    Weapon
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    new public string name = "New Item";
    public Tipe tipe;
    public Sprite icon = null;
    public int ID;
    public int quantity = 0;
    public GameObject item;
}
