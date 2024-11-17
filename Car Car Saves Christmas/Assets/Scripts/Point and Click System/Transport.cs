using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] string temporaryBlockScene;
    [SerializeField] AudioClip temporaryBlockSfx;

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick)
        {
            if (temporaryBlockScene != string.Empty && temporaryBlockSfx != null && !PointAndClickController.visitedScenes.Contains(temporaryBlockScene))
            {
                PointAndClickController.PlayAudioClip(temporaryBlockSfx);
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
