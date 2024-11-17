using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterEvent : MonoBehaviour
{
    [SerializeField] string scene;
    bool readyToTransition;

    private void Start()
    {
        StartCoroutine(ActiavteReadyToTransition());
    }

    private void Update()
    {
        if (readyToTransition && PointAndClickController.instance.canClick)
        {
            SceneManager.LoadScene(scene);
        }
    }

    IEnumerator ActiavteReadyToTransition()
    {
        yield return new WaitForSeconds(1f);

        readyToTransition = true;
    }
}