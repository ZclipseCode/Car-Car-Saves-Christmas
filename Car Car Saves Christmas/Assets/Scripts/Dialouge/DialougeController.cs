using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialougeController : MonoBehaviour
{
    [SerializeField] List<Voiceline> firstEntryVoicelines;
    [SerializeField] string anotherVisitTargetScene;
    [SerializeField] string anotherVisitTargetItem;
    [SerializeField] List<Voiceline> anotherVisitVoicelines;

    private void Start()
    {
        if (!PointAndClickController.visitedScenes.Contains(SceneManager.GetActiveScene().name))
        {
            StartCoroutine(FirstEntry());
        }
        else if (anotherVisitTargetScene != string.Empty &&
            PointAndClickController.visitedScenes.Contains(anotherVisitTargetScene) &&
            !PointAndClickController.anotherVisitedScenes.Contains(anotherVisitTargetScene))
        {
            StartCoroutine(AnotherVisit());
        }
        else if (anotherVisitTargetItem != string.Empty)
        {
            foreach (Item item in PointAndClickController.anotherVisitedItems)
            {
                if (item.itemName == anotherVisitTargetItem)
                {
                    return;
                }
            }

            for (int i = 0; i < PointAndClickController.items.Count; i++)
            {
                if (PointAndClickController.items[i].itemName == anotherVisitTargetItem)
                {
                    StartCoroutine(AnotherVisit());
                    return;
                }
            }
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StopAllCoroutines();

    //        foreach (Voiceline voiceline in firstEntryVoicelines)
    //        {
    //            voiceline.animator.SetBool("isTalking", false);
    //        }

    //        foreach (Voiceline voiceline in anotherVisitVoicelines)
    //        {
    //            if (voiceline.animator != null)
    //            {
    //                voiceline.animator.SetBool("isTalking", false);
    //            }
    //        }

    //        PointAndClickController.instance.canClick = true;
    //    }
    //}

    IEnumerator FirstEntry()
    {
        PointAndClickController.instance.canClick = false;

        PointAndClickController.visitedScenes.Add(SceneManager.GetActiveScene().name);

        foreach (Voiceline voiceline in firstEntryVoicelines)
        {
            PointAndClickController.PlayAudioClip(voiceline.clip);

            if (voiceline.animator != null)
            {
                voiceline.animator.SetBool("isTalking", true);
            }

            yield return new WaitForSeconds(voiceline.clip.length);

            if (voiceline.animator != null)
            {
                voiceline.animator.SetBool("isTalking", false);
            }
        }

        PointAndClickController.instance.canClick = true;
    }

    IEnumerator AnotherVisit()
    {
        PointAndClickController.instance.canClick = false;

        if (anotherVisitTargetScene != string.Empty)
        {
            PointAndClickController.anotherVisitedScenes.Add(anotherVisitTargetScene);
        }
        
        foreach (Item item in PointAndClickController.items)
        {
            if (!PointAndClickController.anotherVisitedItems.Contains(item) && item.itemName == anotherVisitTargetItem)
            {
                PointAndClickController.anotherVisitedItems.Add(item);
            }
        }

        foreach (Voiceline voiceline in anotherVisitVoicelines)
        {
            PointAndClickController.PlayAudioClip(voiceline.clip);

            if (voiceline.animator != null)
            {
                voiceline.animator.SetBool("isTalking", true);
            }

            yield return new WaitForSeconds(voiceline.clip.length);

            if (voiceline.animator != null)
            {
                voiceline.animator.SetBool("isTalking", false);
            }
        }

        PointAndClickController.instance.canClick = true;
    }
}
