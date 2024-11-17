using System;
using UnityEngine;

[Serializable]
public class Item
{
    public string itemName;
    public GameObject itemUIPrefab;
    public AudioClip clip;

    public Item(string itemName, GameObject itemPrefab, AudioClip clip)
    {
        this.itemName = itemName;
        this.itemUIPrefab = itemPrefab;
        this.clip = clip;
    }
}
