using UnityEngine;

public class ReadyEnding : MonoBehaviour
{
    private void Start()
    {
        if (PointAndClickController.visitedScenes.Contains("EvesHouse"))
        {
            EndingAcess.endingReady = true;
        }
    }
}
