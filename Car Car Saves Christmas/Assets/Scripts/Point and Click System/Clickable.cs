using System.Collections;
using UnityEngine;

public class Clickable : MonoBehaviour
{
	[SerializeField] string itemName;
    [SerializeField] GameObject itemUIPrefab;
    [SerializeField] AudioClip clip;
	[SerializeField] bool collectible;
    Animator animator;
	Item item;

    private void Start()
    {
        animator = GetComponent<Animator>();

		item = new Item(itemName, itemUIPrefab, clip);
    }

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick)
		{
            if (collectible)
            {
                StartCoroutine(CollectItem());
            }

            if (animator != null)
            {
                PlayAnimation();
            }

            if (clip != null)
            {
                PlayAudioClip();
            }
        }
    }

	public void PlayAudioClip()
	{
		PointAndClickController.PlayAudioClip(clip);
	}

	public void PlayAnimation()
	{
		animator.SetTrigger("isAnimating");
	}

    IEnumerator CollectItem()
    {
        PointAndClickController.instance.canClick = false;

        PointAndClickController.OnAddItem?.Invoke(item);

        Destroy(gameObject);

        if (clip != null)
        {
            yield return new WaitForSeconds(clip.length);
        }

        PointAndClickController.instance.canClick = true;
    }
}
