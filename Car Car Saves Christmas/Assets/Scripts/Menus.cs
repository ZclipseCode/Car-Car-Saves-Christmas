using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (PointAndClickController.instance != null && InventoryBar.containerInstance != null)
            {
                Destroy(PointAndClickController.instance.gameObject);
                PointAndClickController.instance = null;

                Destroy(InventoryBar.containerInstance.gameObject);
                InventoryBar.containerInstance = null;
            }
        }
        else
        {
            InventoryBar.containerInstance.gameObject.SetActive(false);
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
