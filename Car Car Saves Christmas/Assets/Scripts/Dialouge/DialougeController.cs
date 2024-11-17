using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialougeController : MonoBehaviour
{
    [SerializeField] List<Voiceline> firstEntryVoicelines;
    [SerializeField] string anotherVisitTargetScene;
    [SerializeField] List<Voiceline> anotherVisitVoicelines;

    private void Start()
    {
        if (!PointAndClickController.visitedScenes.Contains(SceneManager.GetActiveScene().name))
        {
            StartCoroutine(FirstEntry());
        }
        else if (anotherVisitTargetScene != string.Empty && !PointAndClickController.anotherVisitedScenes.Contains(SceneManager.GetActiveScene().name))
        {
            StartCoroutine(AnotherVisit());
        }
    }

    IEnumerator FirstEntry()
    {
        PointAndClickController.instance.canClick = false;

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

    IEnumerator AnotherVisit()
    {
        PointAndClickController.instance.canClick = false;

        PointAndClickController.anotherVisitedScenes.Add(SceneManager.GetActiveScene().name);

        foreach (Voiceline voiceline in anotherVisitVoicelines)
        {
            PointAndClickController.PlayAudioClip(voiceline.clip);

            voiceline.animator.SetBool("isTalking", true);

            yield return new WaitForSeconds(voiceline.clip.length);

            voiceline.animator.SetBool("isTalking", false);
        }

        PointAndClickController.instance.canClick = true;
    }
}
