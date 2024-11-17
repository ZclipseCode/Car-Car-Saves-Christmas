using System.Collections;
using UnityEngine;

public class Clickable : MonoBehaviour
{
	[SerializeField] string itemName;
    [SerializeField] GameObject itemUIPrefab;
    [SerializeField] AudioClip clip;
	[SerializeField] bool collectible;
    [SerializeField] string goalItem;
    [SerializeField] bool reciever;
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
            else if (reciever)
            {
                for (int i = 0; i < PointAndClickController.items.Count; i++)
                {
                    Item iteratedItem = PointAndClickController.items[i];

                    if (iteratedItem.itemName == goalItem)
                    {
                        PointAndClickController.OnRemoveItem(PointAndClickController.items[i]);
                    }
                }
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
