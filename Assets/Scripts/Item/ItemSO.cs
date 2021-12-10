using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
}
