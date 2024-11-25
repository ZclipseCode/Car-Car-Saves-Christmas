using UnityEngine;
using System.Collections.Generic;

public class InventoryBar : MonoBehaviour
{
    [SerializeField] RectTransform panel;
    List<Item> items = new List<Item>();
    List<RectTransform> itemTransforms = new List<RectTransform>();
    [SerializeField] GameObject container;
    public static GameObject containerInstance;

    private void Awake()
    {
        if (containerInstance == null)
        {
            containerInstance = container;
            DontDestroyOnLoad(containerInstance);
        }
        else
        {
            Destroy(container);
        }

        PointAndClickController.OnAddItem += AddItem;
        PointAndClickController.OnRemoveItem += RemoveItem;
    }

    void AddItem(Item item)
    {
        items.Add(item);

        GameObject itemPrefab = Instantiate(item.itemUIPrefab, panel);
        itemTransforms.Add(itemPrefab.GetComponent<RectTransform>());

        ArrangeItems();
    }

    void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == item.itemName)
            {
                items.RemoveAt(i);
                Destroy(itemTransforms[i].gameObject);
                itemTransforms.RemoveAt(i);

                break;
            }
        }

        ArrangeItems();
    }

    void ArrangeItems()
    {
        float panelWidth = panel.rect.width;
        float itemsWidth = 0f;

        foreach (RectTransform itemTransform in itemTransforms)
        {
            itemsWidth += itemTransform.rect.width;
        }

        if (itemTransforms.Count > 0 && itemsWidth <= panelWidth)
        {
            float spacing = (panelWidth - itemsWidth) / (itemTransforms.Count + 1);
            float currentX = -panelWidth / 2 + spacing;

            foreach (RectTransform itemTransform in itemTransforms)
            {
                itemTransform.anchoredPosition = new Vector2(currentX + itemTransform.rect.width / 2, itemTransform.anchoredPosition.y);
                currentX += itemTransform.rect.width + spacing;
            }
        }
    }

    private void OnDestroy()
    {
        PointAndClickController.OnAddItem -= AddItem;
        PointAndClickController.OnRemoveItem -= RemoveItem;
    }
}
