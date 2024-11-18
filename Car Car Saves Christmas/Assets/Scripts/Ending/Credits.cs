using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] float waitTime = 3f;
    [SerializeField] RectTransform credits;
    [SerializeField] float speed = 1f;
    bool creditsRolling;

    private void Start()
    {
        StartCoroutine(RollCredits());
    }

    private void Update()
    {
        if (creditsRolling)
        {
            credits.position += new Vector3(0f, speed * Time.deltaTime);
        }
    }

    IEnumerator RollCredits()
    {
        yield return new WaitForSeconds(waitTime);

        creditsRolling = true;
    }
}
