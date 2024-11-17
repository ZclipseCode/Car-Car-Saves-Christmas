using UnityEngine;

public class AlleyCode : MonoBehaviour
{
    [SerializeField] GameObject codeCanvas;
    [SerializeField] AudioClip buttonPress;
    [SerializeField] string code = "123";
    [SerializeField] AudioClip correct;
    [SerializeField] AudioClip incorrect;
    [SerializeField] GameObject transport;
    public static bool accessed;
    string inputtedCode;

    private void Start()
    {
        if (accessed)
        {
            transport.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (PointAndClickController.instance.canClick && !accessed)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        PointAndClickController.instance.canClick = false;

        codeCanvas.SetActive(true);
    }

    public void ButtonPress(int value)
    {
        inputtedCode += value.ToString();
        
        PointAndClickController.PlayAudioClip(buttonPress);

        if (inputtedCode.Length >= 3)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        codeCanvas.SetActive(false);

        PointAndClickController.instance.canClick = true;

        if (inputtedCode != code)
        {
            PointAndClickController.PlayAudioClip(incorrect);

            inputtedCode = string.Empty;
        }
        else
        {
            PointAndClickController.PlayAudioClip(correct);

            transport.SetActive(true);
            accessed = true;

            Destroy(gameObject);
        }
    }
}
