using System.Collections.Generic;
using UnityEngine;

public class PointAndClickController : MonoBehaviour
{
    public static PointAndClickController instance;
    List<Item> items = new List<Item>();
    AudioSource audioSource;
    public bool canClick = true;

    public delegate void ItemHandler(Item item);
    public static ItemHandler OnAddItem;
    public static ItemHandler OnRemoveItem;

    public List<string> visitedScenes = new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        OnAddItem += AddItem;
        OnRemoveItem += RemoveItem;

        audioSource = GetComponent<AudioSource>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public static void PlayAudioClip(AudioClip clip)
    {
        instance.audioSource.PlayOneShot(clip);
    }

    public static void VisitedScene(string scene)
    {
        if (!instance.visitedScenes.Contains(scene))
        {
            instance.visitedScenes.Add(scene);
        }
    }

    private void OnDestroy()
    {
        OnAddItem -= AddItem;
        OnRemoveItem -= RemoveItem;
    }
}
