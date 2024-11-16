using UnityEngine;

public class Item
{
    public string itemName;
    public GameObject itemUIPrefab;

    public Item(string itemName, GameObject itemPrefab)
    {
        this.itemName = itemName;
        this.itemUIPrefab = itemPrefab;
    }
}
