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

		item = new Item(itemName, itemUIPrefab);
    }

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick && PointAndClickController.heldItem == null)
		{
            if (collectible)
            {
                PointAndClickController.OnAddItem?.Invoke(item);
                Destroy(gameObject);
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
}
