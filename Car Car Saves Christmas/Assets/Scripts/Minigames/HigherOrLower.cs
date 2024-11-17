using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HigherOrLower : MonoBehaviour
{
    [SerializeField] AudioClip cardFlipClip;
    [SerializeField] GameObject higher;
    [SerializeField] GameObject lower;
    [SerializeField] GameObject card;
    [SerializeField] List<Sprite> cardFronts = new List<Sprite>();
    [SerializeField] List<float> cardValues = new List<float>();
    [SerializeField] AudioClip correct;
    [SerializeField] AudioClip incorrect;
    [SerializeField] Item reward;
    [SerializeField] Sprite cardBack;
    int randomFirst;
    int randomSecond;
    Image cardImage;

    private void Start()
    {
        cardImage = card.GetComponent<Image>();
    }

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        PointAndClickController.instance.canClick = false;
        PointAndClickController.PlayAudioClip(cardFlipClip);

        randomFirst = Random.Range(0, cardValues.Count);

        cardImage.sprite = cardFronts[randomFirst];

        card.SetActive(true);
        higher.SetActive(true);
        lower.SetActive(true);
    }

    void EndGame()
    {
        card.SetActive(false);

        PointAndClickController.PlayAudioClip(cardFlipClip);
        PointAndClickController.instance.canClick = true;
    }

    public void ArrowButton(bool isHigher)
    {
        StartCoroutine(Flip(isHigher));
    }

    IEnumerator Flip(bool isHigher)
    {
        higher.SetActive(false);
        lower.SetActive(false);

        PointAndClickController.PlayAudioClip(cardFlipClip);

        randomSecond = -1;
        while (randomSecond == -1 || randomSecond == randomFirst)
        {
            randomSecond = Random.Range(0, cardValues.Count);
        }

        cardImage.sprite = cardFronts[randomSecond];

        if (isHigher)
        {
            if (cardValues[randomFirst] > cardValues[randomSecond])
            {
                StartCoroutine(Lose());
                yield break;
            }
        }
        else
        {
            if (cardValues[randomFirst] < cardValues[randomSecond])
            {
                StartCoroutine(Lose());
                yield break;
            }
        }

        PointAndClickController.OnAddItem(reward);
        PointAndClickController.PlayAudioClip(correct);

        yield return new WaitForSeconds(1f);

        EndGame();
    }

    IEnumerator Lose()
    {
        PointAndClickController.PlayAudioClip(incorrect);

        yield return new WaitForSeconds(1f);

        EndGame();

    }
}
