using UnityEngine;

public class Item
{
    public string itemName;
    public Sprite sprite;

    public Item(string itemName, Sprite sprite)
    {
        this.itemName = itemName;
        this.sprite = sprite;
    }
}
