using System.Collections.Generic;
using UnityEngine;

public class ItemSceneController : MonoBehaviour
{
    [SerializeField] List<GameObject> items = new List<GameObject>();

    private void Start()
    {
        List<GameObject> toDestroy = new List<GameObject>();

        foreach (Item item in PointAndClickController.items)
        {
            if (items.Count > 0)
            {
                foreach (GameObject go in items)
                {
                    if (go.name == item.itemName)
                    {
                        toDestroy.Add(go);
                    }
                }
            }
        }

        foreach (GameObject go in toDestroy)
        {
            Destroy(go);
        }
    }
}
