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
    [SerializeField] AudioClip cantCollectSfx;
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
            if (collectible && !reciever)
            {
                CollectItem();
            }
            else if (collectible && reciever)
            {
                for (int i = 0; i < PointAndClickController.items.Count; i++)
                {
                    Item iteratedItem = PointAndClickController.items[i];

                    if (iteratedItem.itemName == goalItem)
                    {
                        PointAndClickController.OnRemoveItem(PointAndClickController.items[i]);
                        CollectItem();
                        PointAndClickController.PlayAudioClip(clip);
                        return;
                    }
                }
            }

            if (animator != null)
            {
                PlayAnimation();
            }

            if (clip != null && !reciever)
            {
                PlayAudioClip();
            }
            else if (reciever)
            {
                PointAndClickController.PlayAudioClip(cantCollectSfx);
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

    void CollectItem()
    {
        PointAndClickController.instance.canClick = false;

        PointAndClickController.OnAddItem?.Invoke(item);

        if (clip != null)
        {
            PointAndClickController.PlayAudioClip(clip);
        }

        PointAndClickController.instance.canClick = true;

        Destroy(gameObject);
    }
}
