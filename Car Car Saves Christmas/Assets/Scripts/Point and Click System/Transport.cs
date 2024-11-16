using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    [SerializeField] string scene;

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
