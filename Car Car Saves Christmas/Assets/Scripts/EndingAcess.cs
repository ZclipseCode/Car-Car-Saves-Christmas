using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingAcess : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] string endingScene;
    [SerializeField] string bothEndingScene;
    [SerializeField] Sprite both;
    [SerializeField] Image message;
    public static bool endingReady = true;
    int items;

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick && endingReady)
        {
            foreach (Item item in PointAndClickController.items)
            {
                if (item.itemName == "Wish List")
                {
                    Prompt();
                    return;
                }
            }
        }
    }

    void Prompt()
    {
        int items = 0;

        foreach (Item item in PointAndClickController.items)
        {
            if (item.itemName == "BoneCrusher24" ||
                item.itemName == "Diesel" ||
                item.itemName == "Batteries")
            {
                items++;
            }
        }

        if (items >= 3)
        {
            message.sprite = both;
        }

        canvas.SetActive(true);
    }

    public void Yes()
    {
        if (items >= 3)
        {
            SceneManager.LoadScene(bothEndingScene);
        }
        else
        {
            SceneManager.LoadScene(endingScene);
        }
    }

    public void No()
    {
        canvas.SetActive(false);
    }
}
