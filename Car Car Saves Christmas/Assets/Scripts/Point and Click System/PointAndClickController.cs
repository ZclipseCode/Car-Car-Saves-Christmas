using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointAndClickController : MonoBehaviour
{
    public static PointAndClickController instance;
    List<Item> items = new List<Item>();
    AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
    }

    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void AddItem(Item item)
    {
        instance.items.Add(item);
    }

    public static void RemoveItem(Item item)
    {
        instance.items.Remove(item);
    }

    public static void PlayAudioClip(AudioClip clip)
    {
        instance.audioSource.PlayOneShot(clip);
    }
}
