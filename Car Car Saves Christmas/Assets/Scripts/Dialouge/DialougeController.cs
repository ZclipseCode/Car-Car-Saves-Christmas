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
        else if (anotherVisitTargetScene != string.Empty && !PointAndClickController.anotherVisitedScenes.Contains(SceneManager.GetActiveScene().name))
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

            if (voiceline.animator == null)
            {
                voiceline.animator = GameObject.FindGameObjectWithTag("BoneCrusher24").GetComponent<Animator>();
            }

            voiceline.animator.SetBool("isTalking", true);

            yield return new WaitForSeconds(voiceline.clip.length);

            voiceline.animator.SetBool("isTalking", false);
        }

        PointAndClickController.instance.canClick = true;
    }
}
