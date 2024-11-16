using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] string itemName;
    bool followMouse;
    RectTransform rectTransform;
    Vector2 originalPosition;
    Item item;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        item = new Item(itemName, gameObject);
    }

    private void Update()
    {
        if (followMouse)
        {
            rectTransform.position = Input.mousePosition;
        }
    }

    public void TriggerFollowMouse()
    {
        if (PointAndClickController.instance.canClick)
        {
            if (!followMouse)
            {
                originalPosition = rectTransform.position;
            }

            followMouse = !followMouse;

            if (!followMouse)
            {
                rectTransform.position = originalPosition;

                PointAndClickController.heldItem = null;
            }
            else
            {
                PointAndClickController.heldItem = item;
            }
        }
    }
}