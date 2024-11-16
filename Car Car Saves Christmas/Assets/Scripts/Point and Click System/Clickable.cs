using UnityEngine;

public class Clickable : MonoBehaviour
{
	[SerializeField] string itemName;
    [SerializeField] AudioClip clip;
	[SerializeField] bool collectible;
    Animator animator;
	Item item;

    private void Start()
    {
        animator = GetComponent<Animator>();

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		item = new Item(itemName, spriteRenderer.sprite);
    }

    private void OnMouseDown()
    {
        if (collectible)
		{
			PointAndClickController.AddItem(item);
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

    public void CollectItem()
	{
		PointAndClickController.AddItem(item);
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
