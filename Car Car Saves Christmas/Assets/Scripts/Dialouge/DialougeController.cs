using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialougeController : MonoBehaviour
{
    [SerializeField] List<Voiceline> firstEntryVoicelines;

    private void Start()
    {
        if (!PointAndClickController.visitedScenes.Contains(SceneManager.GetActiveScene().name))
        {
            PointAndClickController.instance.canClick = false;
            StartCoroutine(FirstEntry());
        }
    }

    IEnumerator FirstEntry()
    {
        PointAndClickController.visitedScenes.Add(SceneManager.GetActiveScene().name);

        foreach (Voiceline voiceline in firstEntryVoicelines)
        {
            PointAndClickController.PlayAudioClip(voiceline.clip);

            voiceline.animator.SetBool("isTalking", true);

            yield return new WaitForSeconds(voiceline.clip.length);

            voiceline.animator.SetBool("isTalking", false);
        }

        PointAndClickController.instance.canClick = true;
    }
}
